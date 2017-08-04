// Copyright (c) 2017 Jan Pluskal, Viliam Letavay
//
//Licensed under the Apache License, Version 2.0 (the "License");
//you may not use this file except in compliance with the License.
//You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
//Unless required by applicable law or agreed to in writing, software
//distributed under the License is distributed on an "AS IS" BASIS,
//WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//See the License for the specific language governing permissions and
//limitations under the License.

/**
 * Autogenerated by Thrift Compiler (0.9.3)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocol;

namespace Netfox.SnooperMessenger.Protocol
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class MNMessagesSyncClientPayload : TBase
  {
    private List<MNMessagesSyncDeltaWrapper> _Deltas;
    private long _FirstDeltaSeqId;
    private long _LastIssuedSeqId;
    private long _QueueEntityId;
    private MNMessagesSyncFailedSend _FailedSend;
    private string _SyncToken;
    private string _ErrorCode;

    public List<MNMessagesSyncDeltaWrapper> Deltas
    {
      get
      {
        return _Deltas;
      }
      set
      {
        __isset.Deltas = true;
        this._Deltas = value;
      }
    }

    public long FirstDeltaSeqId
    {
      get
      {
        return _FirstDeltaSeqId;
      }
      set
      {
        __isset.FirstDeltaSeqId = true;
        this._FirstDeltaSeqId = value;
      }
    }

    public long LastIssuedSeqId
    {
      get
      {
        return _LastIssuedSeqId;
      }
      set
      {
        __isset.LastIssuedSeqId = true;
        this._LastIssuedSeqId = value;
      }
    }

    public long QueueEntityId
    {
      get
      {
        return _QueueEntityId;
      }
      set
      {
        __isset.QueueEntityId = true;
        this._QueueEntityId = value;
      }
    }

    public MNMessagesSyncFailedSend FailedSend
    {
      get
      {
        return _FailedSend;
      }
      set
      {
        __isset.FailedSend = true;
        this._FailedSend = value;
      }
    }

    public string SyncToken
    {
      get
      {
        return _SyncToken;
      }
      set
      {
        __isset.SyncToken = true;
        this._SyncToken = value;
      }
    }

    public string ErrorCode
    {
      get
      {
        return _ErrorCode;
      }
      set
      {
        __isset.ErrorCode = true;
        this._ErrorCode = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool Deltas;
      public bool FirstDeltaSeqId;
      public bool LastIssuedSeqId;
      public bool QueueEntityId;
      public bool FailedSend;
      public bool SyncToken;
      public bool ErrorCode;
    }

    public MNMessagesSyncClientPayload() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.List) {
                {
                  Deltas = new List<MNMessagesSyncDeltaWrapper>();
                  TList _list120 = iprot.ReadListBegin();
                  for( int _i121 = 0; _i121 < _list120.Count; ++_i121)
                  {
                    MNMessagesSyncDeltaWrapper _elem122;
                    _elem122 = new MNMessagesSyncDeltaWrapper();
                    _elem122.Read(iprot);
                    Deltas.Add(_elem122);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.I64) {
                FirstDeltaSeqId = iprot.ReadI64();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.I64) {
                LastIssuedSeqId = iprot.ReadI64();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.I64) {
                QueueEntityId = iprot.ReadI64();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 5:
              if (field.Type == TType.Struct) {
                FailedSend = new MNMessagesSyncFailedSend();
                FailedSend.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 6:
              if (field.Type == TType.String) {
                SyncToken = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 7:
              if (field.Type == TType.String) {
                ErrorCode = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("MNMessagesSyncClientPayload");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Deltas != null && __isset.Deltas) {
          field.Name = "Deltas";
          field.Type = TType.List;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Struct, Deltas.Count));
            foreach (MNMessagesSyncDeltaWrapper _iter123 in Deltas)
            {
              _iter123.Write(oprot);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (__isset.FirstDeltaSeqId) {
          field.Name = "FirstDeltaSeqId";
          field.Type = TType.I64;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(FirstDeltaSeqId);
          oprot.WriteFieldEnd();
        }
        if (__isset.LastIssuedSeqId) {
          field.Name = "LastIssuedSeqId";
          field.Type = TType.I64;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(LastIssuedSeqId);
          oprot.WriteFieldEnd();
        }
        if (__isset.QueueEntityId) {
          field.Name = "QueueEntityId";
          field.Type = TType.I64;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(QueueEntityId);
          oprot.WriteFieldEnd();
        }
        if (FailedSend != null && __isset.FailedSend) {
          field.Name = "FailedSend";
          field.Type = TType.Struct;
          field.ID = 5;
          oprot.WriteFieldBegin(field);
          FailedSend.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (SyncToken != null && __isset.SyncToken) {
          field.Name = "SyncToken";
          field.Type = TType.String;
          field.ID = 6;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(SyncToken);
          oprot.WriteFieldEnd();
        }
        if (ErrorCode != null && __isset.ErrorCode) {
          field.Name = "ErrorCode";
          field.Type = TType.String;
          field.ID = 7;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ErrorCode);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("MNMessagesSyncClientPayload(");
      bool __first = true;
      if (Deltas != null && __isset.Deltas) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Deltas: ");
        __sb.Append(Deltas);
      }
      if (__isset.FirstDeltaSeqId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("FirstDeltaSeqId: ");
        __sb.Append(FirstDeltaSeqId);
      }
      if (__isset.LastIssuedSeqId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("LastIssuedSeqId: ");
        __sb.Append(LastIssuedSeqId);
      }
      if (__isset.QueueEntityId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("QueueEntityId: ");
        __sb.Append(QueueEntityId);
      }
      if (FailedSend != null && __isset.FailedSend) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("FailedSend: ");
        __sb.Append(FailedSend== null ? "<null>" : FailedSend.ToString());
      }
      if (SyncToken != null && __isset.SyncToken) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SyncToken: ");
        __sb.Append(SyncToken);
      }
      if (ErrorCode != null && __isset.ErrorCode) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ErrorCode: ");
        __sb.Append(ErrorCode);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}