﻿using System;
using System.Collections.Generic;

namespace PacketDotNet.Ieee80211
{
    namespace Ieee80211
    {
        /// <summary>
        ///     Every 802.11 frame has a control field that contains information about the frame including
        ///     the 802.11 protocol version, frame type, and various indicators, such as whether WEP is on,
        ///     power management is active.
        /// </summary>
        public class FrameControlField
        {
            /// <summary>
            ///     Sepcifies the frame types down to the sub type level.
            /// </summary>
            public enum FrameSubTypes
            {
                /// <summary>
                ///     Association request
                /// </summary>
                ManagementAssociationRequest = 0x00,

                /// <summary>
                ///     Association response
                /// </summary>
                ManagementAssociationResponse = 0x01,

                /// <summary>
                ///     Reassociation request
                /// </summary>
                ManagementReassociationRequest = 0x02,

                /// <summary>
                ///     Reassociation response
                /// </summary>
                ManagementReassociationResponse = 0x03,

                /// <summary>
                ///     Probe request
                /// </summary>
                ManagementProbeRequest = 0x04,

                /// <summary>
                ///     Probe response
                /// </summary>
                ManagementProbeResponse = 0x5,

                /// <summary>
                ///     Reserved 0
                /// </summary>
                ManagementReserved0 = 0x6,

                /// <summary>
                ///     Reserved 1
                /// </summary>
                ManagementReserved1 = 0x7,

                /// <summary>
                ///     Beacon
                /// </summary>
                ManagementBeacon = 0x8,

                /// <summary>
                ///     ATIM
                /// </summary>
                ManagementATIM = 0x9,

                /// <summary>
                ///     Disassociation
                /// </summary>
                ManagementDisassociation = 0xA,

                /// <summary>
                ///     Authentication
                /// </summary>
                ManagementAuthentication = 0xB,

                /// <summary>
                ///     Deauthentication
                /// </summary>
                ManagementDeauthentication = 0xC,

                /// <summary>
                ///     Reserved 2
                /// </summary>
                ManagementAction = 0xD,

                /// <summary>
                ///     Reserved 3
                /// </summary>
                ManagementReserved3 = 0xE,

                /// <summary>
                ///     Blck Acknowledgment Request (QOS)
                /// </summary>
                ControlBlockAcknowledgmentRequest = 0x18,

                /// <summary>
                ///     Blck Acknowledgment (QOS)
                /// </summary>
                ControlBlockAcknowledgment = 0x19,

                /// <summary>
                ///     PS poll
                /// </summary>
                ControlPSPoll = 0x1A,

                /// <summary>
                ///     RTS
                /// </summary>
                ControlRTS = 0x1B,

                /// <summary>
                ///     CTS
                /// </summary>
                ControlCTS = 0x1C,

                /// <summary>
                ///     ACK
                /// </summary>
                ControlACK = 0x1D,

                /// <summary>
                ///     CF-End
                /// </summary>
                ControlCFEnd = 0x1E,

                /// <summary>
                ///     CF-End CF-Ack
                /// </summary>
                ControlCFEndCFACK = 0x1F,

                /// <summary>
                ///     Data
                /// </summary>
                Data = 0x20,

                /// <summary>
                ///     CF-ACK
                /// </summary>
                DataCFACK = 0x21,

                /// <summary>
                ///     CF-Poll
                /// </summary>
                DataCFPoll = 0x22,

                /// <summary>
                ///     CF-Ack CF-Poll
                /// </summary>
                DataCFAckCFPoll = 0x23,

                /// <summary>
                ///     Null function no data
                /// </summary>
                DataNullFunctionNoData = 0x24,

                /// <summary>
                ///     CF-Ack No data
                /// </summary>
                DataCFAckNoData = 0x25,

                /// <summary>
                ///     CF-Poll no data
                /// </summary>
                DataCFPollNoData = 0x26,

                /// <summary>
                ///     CF-Ack CF-Poll no data
                /// </summary>
                DataCFAckCFPollNoData = 0x27,

                /// <summary>
                ///     Constant qos data.
                /// </summary>
                QosData = 0x28,

                /// <summary>
                ///     Constant qos data and CF ack.
                /// </summary>
                QosDataAndCFAck = 0x29,

                /// <summary>
                ///     Constant qos data and CF poll.
                /// </summary>
                QosDataAndCFPoll = 0x2A,

                /// <summary>
                ///     Constant qos data and CF ack and CF poll.
                /// </summary>
                QosDataAndCFAckAndCFPoll = 0x2B,

                /// <summary>
                ///     Constant qos null data.
                /// </summary>
                QosNullData = 0x2C,

                /// <summary>
                ///     Constant qos CF ack.
                /// </summary>
                QosCFAck = 0x2D,

                /// <summary>
                ///     Constant qos CF poll.
                /// </summary>
                QosCFPoll = 0x2E,

                /// <summary>
                ///     Constant qos CF ack and CF poll.
                /// </summary>
                QosCFAckAndCFPoll = 0x2F
            };

            /// <summary>
            ///     Specifies the main frame type: Control, Management or Data.
            /// </summary>
            public enum FrameTypes
            {
                /// <summary>
                ///     Management frame.
                /// </summary>
                Management = 0,

                /// <summary>
                ///     Control frame.
                /// </summary>
                Control = 1,

                /// <summary>
                ///     Data frame.
                /// </summary>
                Data = 2
            }

            /// <summary>
            ///     Initializes a new instance of the <see cref="FrameControlField" /> class.
            /// </summary>
            public FrameControlField() { }

            /// <summary>
            ///     Constructor
            /// </summary>
            /// <param name="field">
            ///     A <see cref="UInt16" />
            /// </param>
            public FrameControlField(UInt16 field) { this.Field = field; }

            /// <summary>
            ///     Protocol version
            /// </summary>
            public byte ProtocolVersion
            {
                get { return (byte) ((this.Field >> 0x8)&0x3); }

                set
                {
                    if((value < 0) || (value > 3)) { throw new ArgumentException("Invalid protocol version value. Value must be in the range 0-3."); }

                    //unset the two bits before setting them to the value
                    this.Field &= unchecked((UInt16) ~(0x0300));
                    this.Field |= (UInt16) (value << 0x8);
                }
            }

            /// <summary>
            ///     Gets the type of the frame.
            /// </summary>
            /// <value>
            ///     The type.
            /// </value>
            public FrameTypes Type
            {
                get
                {
                    var typeAndSubtype = (this.Field >> 8); //get rid of the flags
                    var type = ((typeAndSubtype&0xC) >> 2);
                    return (FrameTypes) type;
                }
            }

            /// <summary>
            ///     Helps to identify the type of WLAN frame, control data and management are
            ///     the various frame types defined in IEEE 802.11
            /// </summary>
            public FrameSubTypes SubType
            {
                get
                {
                    var typeAndSubtype = (this.Field >> 8); //get rid of the flags
                    var type = (((typeAndSubtype&0x0C) << 2)|(typeAndSubtype >> 4));
                    return (FrameSubTypes) type;
                }

                set
                {
                    var val = (uint) value;
                    var typeAndSubtype = ((val&0x0F) << 4)|((val >> 4) << 2);
                    //shift it into the right position in the field
                    typeAndSubtype = typeAndSubtype << 0x8;
                    //Unset all the bits related to the type and subtype
                    this.Field &= 0x03FF;
                    //Set the type bits
                    this.Field |= (UInt16) typeAndSubtype;
                }
            }

            /// <summary>
            ///     Is set to 1 when the frame is sent to Distribution System (DS)
            /// </summary>
            public bool ToDS
            {
                get { return ((this.Field&0x1) == 1)? true : false; }

                set
                {
                    if(value) { this.Field |= 0x1; }
                    else
                    { this.Field &= unchecked((UInt16) ~(0x1)); }
                }
            }

            /// <summary>
            ///     Is set to 1 when the frame is received from the Distribution System (DS)
            /// </summary>
            public bool FromDS
            {
                get { return (((this.Field >> 1)&0x1) == 1)? true : false; }

                set
                {
                    if(value) { this.Field |= (1 << 0x1); }
                    else
                    { this.Field &= unchecked((UInt16) ~(1 << 0x1)); }
                }
            }

            /// <summary>
            ///     More Fragment is set to 1 when there are more fragments belonging to the same
            ///     frame following the current fragment
            /// </summary>
            public bool MoreFragments
            {
                get { return (((this.Field >> 2)&0x1) == 1)? true : false; }

                set
                {
                    if(value) { this.Field |= (1 << 0x2); }
                    else
                    { this.Field &= unchecked((UInt16) ~(1 << 0x2)); }
                }
            }

            /// <summary>
            ///     Indicates that this fragment is a retransmission of a previously transmitted fragment.
            ///     (For receiver to recognize duplicate transmissions of frames)
            /// </summary>
            public bool Retry
            {
                get { return (((this.Field >> 3)&0x1) == 1)? true : false; }

                set
                {
                    if(value) { this.Field |= (1 << 0x3); }
                    else
                    { this.Field &= unchecked((UInt16) ~(1 << 0x3)); }
                }
            }

            /// <summary>
            ///     Indicates the power management mode that the station will be in after the transmission of the frame
            /// </summary>
            public bool PowerManagement
            {
                get { return (((this.Field >> 4)&0x1) == 1)? true : false; }

                set
                {
                    if(value) { this.Field |= (1 << 0x4); }
                    else
                    { this.Field &= unchecked((UInt16) ~(1 << 0x4)); }
                }
            }

            /// <summary>
            ///     Indicates that there are more frames buffered for this station
            /// </summary>
            public bool MoreData
            {
                get { return (((this.Field >> 5)&0x1) == 1)? true : false; }

                set
                {
                    if(value) { this.Field |= (1 << 0x5); }
                    else
                    { this.Field &= unchecked((UInt16) ~(1 << 0x5)); }
                }
            }

            /// <summary>
            ///     Indicates that the frame body is encrypted according to the WEP (wired equivalent privacy) algorithm
            /// </summary>
            public bool Wep
            {
                get { return (((this.Field >> 6)&0x1) == 1)? true : false; }

                set
                {
                    if(value) { this.Field |= (1 << 0x6); }
                    else
                    { this.Field &= unchecked((UInt16) ~(1 << 0x6)); }
                }
            }

            /// <summary>
            ///     Bit is set when the "strict ordering" delivery method is employed. Frames and
            ///     fragments are not always sent in order as it causes a transmission performance penalty.
            /// </summary>
            public bool Order
            {
                get { return (((this.Field >> 0x7)&0x1) == 1)? true : false; }

                set
                {
                    if(value) { this.Field |= (1 << 0x7); }
                    else
                    { this.Field &= unchecked((UInt16) ~(1 << 0x7)); }
                }
            }

            /// <summary>
            ///     Gets or sets the field.
            /// </summary>
            /// <value>
            ///     The field.
            /// </value>
            public UInt16 Field { get; set; }

            /// <summary>
            ///     Returns a <see cref="System.String" /> that represents the current <see cref="FrameControlField" />.
            /// </summary>
            /// <returns>
            ///     A <see cref="System.String" /> that represents the current <see cref="FrameControlField" />.
            /// </returns>
            public override string ToString()
            {
                var flags = new List<String>();

                flags.Add(this.SubType.ToString());

                if(this.ToDS) { flags.Add("ToDS"); }
                if(this.FromDS) { flags.Add("FromDS"); }
                if(this.Retry) { flags.Add("Retry"); }
                if(this.PowerManagement) { flags.Add("PowerManagement"); }
                if(this.MoreData) { flags.Add("MoreData"); }
                if(this.Wep) { flags.Add("Wep"); }
                if(this.Order) { flags.Add("Order"); }

                return String.Join(" ", flags.ToArray());
            }
        }
    }
}