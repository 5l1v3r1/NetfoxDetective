﻿using System;
using System.Linq;
using PacketDotNet.Utils;

namespace PacketDotNet.Ieee80211
{
    namespace Ieee80211
    {
        /// <summary>
        ///     Information element, a variable-length component of management frames
        /// </summary>
        /// <exception cref='ArgumentException'>
        ///     Is thrown when an argument passed to a method is invalid.
        /// </exception>
        public class InformationElement
        {
            /// <summary>
            ///     Types of information elements
            /// </summary>
            public enum ElementId
            {
                /// <summary>
                ///     Assign an identifier to the service set
                /// </summary>
                ServiceSetIdentity = 0x00,

                /// <summary>
                ///     Specifies the data rates supported by the network
                /// </summary>
                SupportedRates = 0x01,

                /// <summary>
                ///     Provides the parameters necessary to join a frequency-hopping 802.11 network
                /// </summary>
                FhParamterSet = 0x02,

                /// <summary>
                ///     Direct-sequence 802.11 networks have one parameter, the channel number of the network
                /// </summary>
                DsParameterSet = 0x03,

                /// <summary>
                ///     Contention-free parameter. Transmitted in Becons by access points that support
                ///     contention-free operation.
                /// </summary>
                CfParameterSet = 0x04,

                /// <summary>
                ///     Indicates which stations have buffered traffic waiting to be picked up
                /// </summary>
                TrafficIndicationMap = 0x05,

                /// <summary>
                ///     Indicates the number of time units (TUs) between ATIM frames in an IBSS.
                /// </summary>
                IbssParameterSet = 0x06,

                /// <summary>
                ///     Specifies regulatory constraints stations must adhere to based on the country the network is operating in.
                /// </summary>
                Country = 0x07,

                /// <summary>
                ///     Specifies the hopping pattern of timeslots used in frequency hopping physical layers.
                /// </summary>
                HoppingParametersPattern = 0x08,

                /// <summary>
                ///     Specifies the hopping pattern table used in frequency hopping physical layers.
                /// </summary>
                HoppingPatternTable = 0x09,

                /// <summary>
                ///     Specifies the Ids of the information elements being requested in a <see cref="ProbeRequestFrame" />.
                /// </summary>
                Request = 0x0A,

                /// <summary>
                ///     Specifies the encrypted challenge text that stations must decrypt as part of the authentication process.
                /// </summary>
                ChallengeText = 0x10,

                /// <summary>
                ///     Specifies the difference between the regulatory maximum transmit power and any local constraint.
                /// </summary>
                PowerContstraint = 0x20,

                /// <summary>
                ///     Specifies the minimum and maximum transmit power a station is capable of.
                /// </summary>
                PowerCapability = 0x21,

                /// <summary>
                ///     Used to request radio link management information. This type of information element never has an associated value.
                /// </summary>
                TransmitPowerControlRequest = 0x22,

                /// <summary>
                ///     Radio link managment report used by stations to tune their transmission power.
                /// </summary>
                TransmitPowerControlReport = 0x23,

                /// <summary>
                ///     Specifies local constraints on the channels in use.
                /// </summary>
                SupportedChannels = 0x24,

                /// <summary>
                ///     Announces an impending change of channel for the network.
                /// </summary>
                ChannelSwitchAnnouncement = 0x25,

                /// <summary>
                ///     Requests a report on the state of the radio channel.
                /// </summary>
                MeasurementRequest = 0x26,

                /// <summary>
                ///     A report of on the status of the radio channel.
                /// </summary>
                MeasurementReport = 0x27,

                /// <summary>
                ///     Specifies the scheduling of temporary quiet periods on the channel.
                /// </summary>
                Quiet = 0x28,

                /// <summary>
                ///     Specifies the details the Dynamic Frequency Selection (DFS) algorithm in use in the IBSS.
                /// </summary>
                IbssDfs = 0x29,

                /// <summary>
                ///     Indicates whether or not the Extended Rate PHY is in use on the network at that time.
                /// </summary>
                ErpInformation = 0x2A,

                /// <summary>
                ///     Specifies a stations high throughput capabilities.
                /// </summary>
                HighThroughputCapabilities = 0x2d,
                ErpInformation2 = 0x2F,

                /// <summary>
                ///     Specifies details of the Robust Security Network encryption in use on the network.
                /// </summary>
                RobustSecurityNetwork = 0x30,

                /// <summary>
                ///     Specifies more data rates supported by the network. This is identical to the Supported Rates element but it allows
                ///     for a longer value.
                /// </summary>
                ExtendedSupportedRates = 0x32,

                /// <summary>
                ///     Specified how high throughput capable stations will be operated in the network.
                /// </summary>
                HighThroughputInformation = 0x3d,

                /// <summary>
                ///     Specifies details of the WiFi Protected Access encryption in use on the network.
                /// </summary>
                WifiProtectedAccess = 0xD3,

                /// <summary>
                ///     Non standard information element implemented by the hardware vendor.
                /// </summary>
                VendorSpecific = 0xDD
            }

            /// <summary>
            ///     The length in bytes of the Information Element id field.
            /// </summary>
            public static readonly int ElementIdLength = 1;

            /// <summary>
            ///     The length in bytes of the Information Element length field.
            /// </summary>
            public static readonly int ElementLengthLength = 1;

            /// <summary>
            ///     The index of the id field in an Information Element.
            /// </summary>
            public static readonly int ElementIdPosition = 0;

            /// <summary>
            ///     The index of the length field in an Information Element.
            /// </summary>
            public static readonly int ElementLengthPosition;

            /// <summary>
            ///     The index of the first byte of the value field in an Information Element.
            /// </summary>
            public static readonly int ElementValuePosition;

            private ByteArraySegment bytes;

            static InformationElement()
            {
                ElementLengthPosition = ElementIdPosition + ElementIdLength;
                ElementValuePosition = ElementLengthPosition + ElementLengthLength;
            }

            /// <summary>
            ///     Initializes a new instance of the <see cref="InformationElement" /> class.
            /// </summary>
            /// <param name='bas'>
            ///     The bytes of the information element. The Offset property should point to the first byte of the element, the Id
            ///     byte
            /// </param>
            public InformationElement(ByteArraySegment bas) { this.bytes = bas; }

            /// <summary>
            ///     Initializes a new instance of the <see cref="InformationElement" /> class.
            /// </summary>
            /// <param name='id'>
            ///     Identifier.
            /// </param>
            /// <param name='value'>
            ///     Value.
            /// </param>
            /// <exception cref='ArgumentException'>
            ///     Is thrown when an argument passed to a method is invalid.
            /// </exception>
            public InformationElement(ElementId id, Byte[] value)
            {
                var ie = new Byte[ElementIdLength + ElementLengthLength + value.Length];
                this.bytes = new ByteArraySegment(ie);
                this.Id = id;
                this.Value = value;
            }

            /// <summary>
            ///     Gets or sets the identifier.
            /// </summary>
            /// <value>
            ///     The identifier.
            /// </value>
            public ElementId Id
            {
                get { return (ElementId) this.bytes.Bytes[this.bytes.Offset + ElementIdPosition]; }
                set { this.bytes.Bytes[this.bytes.Offset + ElementIdPosition] = (byte) value; }
            }

            /// <summary>
            ///     Gets the length.
            /// </summary>
            /// <value>
            ///     The length.
            /// </value>
            public int ValueLength
            {
                get { return Math.Min((this.bytes.Length - ElementValuePosition), this.bytes.Bytes[this.bytes.Offset + ElementLengthPosition]); }
                //no set Length method as we dont want to allow a mismatch between
                //the length field and the actual length of the value
            }

            /// <summary>
            ///     Gets the length of the element including the Id and Length field
            /// </summary>
            /// <value>
            ///     The length of the element.
            /// </value>
            public byte ElementLength
            {
                get { return (byte) (ElementIdLength + ElementLengthLength + this.ValueLength); }
                //no set Length method as we dont want to allow a mismatch between
                //the length field and the actual length of the value
            }

            /// <summary>
            ///     Gets or sets the value of the element
            /// </summary>
            /// <value>
            ///     The value.
            /// </value>
            /// <exception cref='ArgumentException'>
            ///     Is thrown when the value is too large. Values are limited to a maximum size 255 bytes due the single
            ///     byte length field.
            /// </exception>
            public Byte[] Value
            {
                get
                {
                    var valueArray = new Byte[this.ValueLength];
                    Array.Copy(this.bytes.Bytes, this.bytes.Offset + ElementValuePosition, valueArray, 0, this.ValueLength);
                    return valueArray;
                }

                set
                {
                    if(value.Length > byte.MaxValue) { throw new ArgumentException("The provided value is too long. Maximum allowed length is 255 bytes."); }
                    //Decide if the current ByteArraySegement is big enough to hold the new info element
                    var newIeLength = ElementIdLength + ElementLengthLength + value.Length;
                    if(this.bytes.Length < newIeLength)
                    {
                        var newIe = new Byte[newIeLength];
                        newIe[ElementIdPosition] = this.bytes.Bytes[this.bytes.Offset + ElementIdPosition];
                        this.bytes = new ByteArraySegment(newIe);
                    }

                    Array.Copy(value, 0, this.bytes.Bytes, this.bytes.Offset + ElementValuePosition, value.Length);
                    this.bytes.Length = newIeLength;
                    this.bytes.Bytes[this.bytes.Offset + ElementLengthPosition] = (byte) value.Length;
                }
            }

            /// <summary>
            ///     Gets the bytes.
            /// </summary>
            /// <value>
            ///     The bytes.
            /// </value>
            public Byte[] Bytes
            {
                get { return this.bytes.ActualBytes(); }
            }

            /// <summary>
            ///     Determines whether the specified <see cref="System.Object" /> is equal to the current
            ///     <see cref="InformationElement" />.
            /// </summary>
            /// <param name='obj'>
            ///     The <see cref="System.Object" /> to compare with the current <see cref="InformationElement" />.
            /// </param>
            /// <returns>
            ///     <c>true</c> if the specified <see cref="System.Object" /> is equal to the current
            ///     <see cref="InformationElement" />; otherwise, <c>false</c>.
            /// </returns>
            public override bool Equals(object obj)
            {
                if(obj == null || this.GetType() != obj.GetType()) { return false; }

                var ie = obj as InformationElement;
                return ((this.Id == ie.Id) && (this.Value.SequenceEqual(ie.Value)));
            }

            /// <summary>
            ///     Serves as a hash function for a <see cref="InformationElement" /> object.
            /// </summary>
            /// <returns>
            ///     A hash code for this instance that is suitable for use in hashing algorithms and data structures such as
            ///     a hash table.
            /// </returns>
            public override int GetHashCode() { return this.Id.GetHashCode()^this.Value.GetHashCode(); }
        }
    }
}