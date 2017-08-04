using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Netfox.Framework.Models;
using Netfox.Framework.Models.PmLib.SupportedTypes;
using PacketParser;
using PacketParser.Packets;
using ProtocolIdentification;

namespace Spid
{
    internal class SessionAndProtocolModelExtractorFlow
    {
        private readonly Queue<KeyValuePair<ISession, ProtocolModel>> _completedProtocolModelsQueue; //30*256*(8+8)=~120kB per item
        private readonly SortedList<String, ProtocolModel> _protocolModels;
        private readonly Configuration config;
        private readonly Queue<Frame> frameQueue; //~1kB per item
        private Task _backgroundFileLoader, _backgroundFrameToSessionAdder;
        private L4Conversation _conversation;
        private Type _packetBaseType;
        private SessionHandler _sessionHandler;
        private AutoResetEvent fillInQueueAutoResetEvent = new AutoResetEvent(false);

        public SessionAndProtocolModelExtractorFlow(SortedList<String, ProtocolModel> protocolModels, Configuration config)
        {
            this.config = config;
            this._protocolModels = protocolModels;


            this.frameQueue = new Queue<Frame>(); //(this._frameQueueMaxSize);
            this._completedProtocolModelsQueue = new Queue<KeyValuePair<ISession, ProtocolModel>>();

            this._backgroundFileLoader = new Task(this.backgroundFileLoader_DoWork);
            this._backgroundFrameToSessionAdder = new Task(this.backgroundFrameToSessionAdder_DoWork);
        }

        public String RunRecognition(L4Conversation conversation)
        {
            this._conversation = conversation;
            if(!this.SetPacketBaseType()) { return null; }

            this._completedProtocolModelsQueue.Clear();
            this.frameQueue.Clear();

            this._sessionHandler = new SessionHandler(this.config.MaxSimultaneousSessions, this.config); //1000 parallel sessions is a good value
            this._sessionHandler.SessionProtocolModelCompleted += this.sessionHandler_SessionProtocolModelCompleted;

            this._backgroundFileLoader = new Task(this.backgroundFileLoader_DoWork);
            this._backgroundFrameToSessionAdder = new Task(this.backgroundFrameToSessionAdder_DoWork);


            this._backgroundFileLoader.Start();
            this._backgroundFrameToSessionAdder.Start();

            this._backgroundFileLoader.Wait();
            this._backgroundFrameToSessionAdder.Wait();
            var sessions = this._sessionHandler.GetSessionsWithoutCompletedProtocolModels();
            // Debug.Assert(sessions.Count() == 1);
            var protocols =
                sessions.Select(session => this.GetBestProtocolMatch(session.ApplicationProtocolModel, this._protocolModels)).Where(protocol => protocol != null).ToList();
            protocols.AddRange(
                this._completedProtocolModelsQueue.Select(session => session.Value != null? this.GetBestProtocolMatch(session.Value, this._protocolModels) : null)
                    .Where(protocol => protocol != null));
            if(protocols.Any())
            {
                if(protocols.Count != 1)
                {
                    Debug.Write("Recognized more conversations tags> ");
                    foreach(var proto in protocols) { Debug.Write(proto + " "); }
                    Debug.WriteLine("");
                }

                return protocols.First().ToString();
            }
            return null;
        }

        private void backgroundFileLoader_DoWork()
        {
            //LoadingProcess lp=(LoadingProcess)e.Argument;
            var nFramesReceived = 0;

            foreach(var frame in this._conversation.Frames.OrderBy(f => f.FrameIndex))
            {
                //var millisecondsToSleep = 1;
                //while (frameQueue.Count >= _frameQueueMaxSize)
                //{
                //    Thread.Sleep(millisecondsToSleep);
                //    millisecondsToSleep = Math.Min(2 * millisecondsToSleep, 5000);
                //}
                lock(this.frameQueue) { this.frameQueue.Enqueue(new Frame(frame.TimeStamp, frame.L2Data(), this._packetBaseType, ++nFramesReceived, false)); }
                this.fillInQueueAutoResetEvent.Set();
            }
            //Thread.Sleep(100);

            ////this.backgroundFileLoaderCompleted=true;
        }

        private void backgroundFrameToSessionAdder_DoWork()
        {
            //var bufferUsage=0;
            //var millisecondsToSleep=1;
            while(!this._backgroundFileLoader.IsCompleted || this.frameQueue.Count > 0)
            {
                //    if(frameQueue.Count>0 && _completedProtocolModelsQueue.Count<_completedProtocolModelsQueueMaxSize) {
                //        millisecondsToSleep=1;
                //        Frame frame;
                //        lock(frameQueue) {
                //            frame=frameQueue.Dequeue();
                //        }
                //        ISession session;
                //        if(_sessionHandler.TryGetSession(frame, out session)) {
                //            session.AddFrame(frame);
                //        }
                //    }
                //    else {
                //        Thread.Sleep(millisecondsToSleep);
                //        millisecondsToSleep=Math.Min(2*millisecondsToSleep, 5000);
                //    }
                if(this.frameQueue.Count > 0)
                {
                    Frame frame;
                    lock(this.frameQueue) { frame = this.frameQueue.Dequeue(); }
                    ISession session;
                    if(this._sessionHandler.TryGetSession(frame, out session)) { session.AddFrame(frame); }
                }
                else
                {
                    this.fillInQueueAutoResetEvent.WaitOne(100);
                }
            }
        }

        private ProtocolModel GetBestProtocolMatch(ProtocolModel observationModel, SortedList<String, ProtocolModel> protocolModels)
        {
            ProtocolModel bestProtocolMatch = null;
            var bestProtocolMatchDivergence = this.config.DivergenceThreshold; //the highest allowed distance for a valid protocol model match

            foreach(var protocolModel in this._protocolModels.Values)
            {
                var divergence = observationModel.GetAverageKullbackLeiblerDivergenceFrom(protocolModel);
                if(divergence < bestProtocolMatchDivergence)
                {
                    bestProtocolMatch = protocolModel;
                    bestProtocolMatchDivergence = divergence;
                }
            }

            //TODO I have no idea why this is not working...
            //var _protocolModelsDivergences = new double[_protocolModels.Values.Count];
            //var _protocolModelsResulting = new ProtocolModel[_protocolModels.Values.Count];
            //Parallel.ForEach(_protocolModels.Values, (i, state, index) =>
            //{
            //    _protocolModelsDivergences[index] = observationModel.GetAverageKullbackLeiblerDivergenceFrom(i);
            //    _protocolModelsResulting[index] = i;
            //});

            //for (int index = 0; index < _protocolModelsDivergences.Length; index++)
            //{
            //    double divergence = _protocolModelsDivergences[index];
            //    if (bestProtocolMatchDivergence > divergence)
            //    {
            //        bestProtocolMatchDivergence = divergence;
            //        bestProtocolMatch = _protocolModelsResulting[index];
            //    }
            //}

            return bestProtocolMatch;
        }

        private void sessionHandler_SessionProtocolModelCompleted(ISession session, ProtocolModel protocolModel)
        {
            //this.completedProtocolModels.Add(session, protocolModel);
            lock(this._completedProtocolModelsQueue) { this._completedProtocolModelsQueue.Enqueue(new KeyValuePair<ISession, ProtocolModel>(session, protocolModel)); }
        }

        private Boolean SetPacketBaseType()
        {
            this._packetBaseType = null;
            //TODO other types mapping
            switch(this._conversation.Frames.First()?.PmLinkType)
            {
                case PmLinkType.Ethernet:
                    this._packetBaseType = typeof(Ethernet2Packet);
                    break;
                case PmLinkType.Raw:
                    this._packetBaseType = typeof(IPv4Packet);
                    break;
                case PmLinkType.Ieee80211:
                    this._packetBaseType = typeof(IEEE_802_11Packet);
                    break;
                default:
                    return false;
            }
            return true;
        }

        private delegate void EmptyDelegateCallback();
    }
}