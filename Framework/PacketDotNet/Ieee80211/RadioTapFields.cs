﻿using System;
using System.IO;
using PacketDotNet.MiscUtil.Conversion;

namespace PacketDotNet.Ieee80211
{
    namespace Ieee80211
    {
        /// <summary>
        ///     Channel field
        /// </summary>
        public class ChannelRadioTapField : RadioTapField
        {
            /// <summary>
            ///     Channel flags
            /// </summary>
            public RadioTapChannelFlags Flags;

            /// <summary>
            ///     Constructor
            /// </summary>
            /// <param name="br">
            ///     A <see cref="BinaryReader" />
            /// </param>
            public ChannelRadioTapField(BinaryReader br)
            {
                this.FrequencyMHz = br.ReadUInt16();
                this.Channel = ChannelFromFrequencyMHz(this.FrequencyMHz);
                this.Flags = (RadioTapChannelFlags) br.ReadUInt16();
            }

            /// <summary>
            ///     Initializes a new instance of the <see cref="ChannelRadioTapField" /> class.
            /// </summary>
            public ChannelRadioTapField() { }

            /// <summary>
            ///     Initializes a new instance of the <see cref="ChannelRadioTapField" /> class.
            /// </summary>
            /// <param name='FrequencyMhz'>
            ///     Tx/Rx Frequency in MHz.
            /// </param>
            /// <param name='Flags'>
            ///     Flags.
            /// </param>
            public ChannelRadioTapField(UInt16 FrequencyMhz, RadioTapChannelFlags Flags)
            {
                this.FrequencyMHz = this.FrequencyMHz;
                this.Channel = ChannelFromFrequencyMHz(this.FrequencyMHz);
                this.Flags = Flags;
            }

            /// <summary>Type of the field</summary>
            public override RadioTapType FieldType
            {
                get { return RadioTapType.Channel; }
            }

            /// <summary>
            ///     Gets the length of the field data.
            /// </summary>
            /// <value>
            ///     The length.
            /// </value>
            public override ushort Length
            {
                get { return 4; }
            }

            /// <summary>
            ///     Frequency in MHz
            /// </summary>
            public UInt16 FrequencyMHz { get; set; }

            /// <summary>
            ///     Channel number derived from frequency
            /// </summary>
            public int Channel { get; set; }

            /// <summary>
            ///     Convert a frequency to a channel
            /// </summary>
            /// <remarks>
            ///     There is some overlap between the 802.11b/g channel numbers and the 802.11a channel numbers. This means that while
            ///     a particular frequncy will only
            ///     ever map to single channel number the same channel number may be returned for more than one frequency. At present
            ///     this affects channel numbers 8 and 12.
            /// </remarks>
            /// <param name="frequencyMHz">
            ///     A <see cref="System.Int32" />
            /// </param>
            /// <returns>
            ///     A <see cref="System.Int32" />
            /// </returns>
            public static int ChannelFromFrequencyMHz(int frequencyMHz)
            {
                switch(frequencyMHz)
                {
                    //802.11 bg channel numbers
                    case 2412:
                        return 1;
                    case 2417:
                        return 2;
                    case 2422:
                        return 3;
                    case 2427:
                        return 4;
                    case 2432:
                        return 5;
                    case 2437:
                        return 6;
                    case 2442:
                        return 7;
                    case 2447:
                        return 8;
                    case 2452:
                        return 9;
                    case 2457:
                        return 10;
                    case 2462:
                        return 11;
                    case 2467:
                        return 12;
                    case 2472:
                        return 13;
                    case 2484:
                        return 14;
                    //802.11 a channel numbers
                    case 4920:
                        return 240;
                    case 4940:
                        return 244;
                    case 4960:
                        return 248;
                    case 4980:
                        return 252;
                    case 5040:
                        return 8;
                    case 5060:
                        return 12;
                    case 5080:
                        return 16;
                    case 5170:
                        return 34;
                    case 5180:
                        return 36;
                    case 5190:
                        return 38;
                    case 5200:
                        return 40;
                    case 5210:
                        return 42;
                    case 5220:
                        return 44;
                    case 5230:
                        return 46;
                    case 5240:
                        return 48;
                    case 5260:
                        return 52;
                    case 5280:
                        return 56;
                    case 5300:
                        return 60;
                    case 5320:
                        return 64;
                    case 5500:
                        return 100;
                    case 5520:
                        return 104;
                    case 5540:
                        return 108;
                    case 5560:
                        return 112;
                    case 5580:
                        return 116;
                    case 5600:
                        return 120;
                    case 5620:
                        return 124;
                    case 5640:
                        return 128;
                    case 5660:
                        return 132;
                    case 5680:
                        return 136;
                    case 5700:
                        return 140;
                    case 5745:
                        return 149;
                    case 5765:
                        return 153;
                    case 5785:
                        return 157;
                    case 5805:
                        return 161;
                    case 5825:
                        return 165;
                    default:
                        return 0;
                }
                ;
            }

            /// <summary>
            ///     Copies the field data to the destination buffer at the specified offset.
            /// </summary>
            public override void CopyTo(byte[] dest, int offset)
            {
                EndianBitConverter.Little.CopyBytes(this.FrequencyMHz, dest, offset);
                EndianBitConverter.Little.CopyBytes((UInt16) this.Flags, dest, offset + 2);
            }

            /// <summary>
            ///     ToString() override
            /// </summary>
            /// <returns>
            ///     A <see cref="System.String" />
            /// </returns>
            public override string ToString() { return string.Format("FrequencyMHz {0}, Channel {1}, Flags {2}", this.FrequencyMHz, this.Channel, this.Flags); }
        }

        /// <summary>
        ///     Fhss radio tap field
        /// </summary>
        public class FhssRadioTapField : RadioTapField
        {
            /// <summary>
            ///     Constructor
            /// </summary>
            /// <param name="br">
            ///     A <see cref="BinaryReader" />
            /// </param>
            public FhssRadioTapField(BinaryReader br)
            {
                var u16 = br.ReadUInt16();

                this.ChannelHoppingSet = (byte) (u16&0xff);
                this.Pattern = (byte) ((u16 >> 8)&0xff);
            }

            /// <summary>
            ///     Initializes a new instance of the <see cref="FhssRadioTapField" /> class.
            /// </summary>
            public FhssRadioTapField() { }

            /// <summary>
            ///     Initializes a new instance of the <see cref="FhssRadioTapField" /> class.
            /// </summary>
            /// <param name='ChannelHoppingSet'>
            ///     Channel hopping set.
            /// </param>
            /// <param name='Pattern'>
            ///     Channel hopping pattern.
            /// </param>
            public FhssRadioTapField(byte ChannelHoppingSet, byte Pattern)
            {
                this.ChannelHoppingSet = ChannelHoppingSet;
                this.Pattern = Pattern;
            }

            /// <summary>Type of the field</summary>
            public override RadioTapType FieldType
            {
                get { return RadioTapType.Fhss; }
            }

            /// <summary>
            ///     Gets the length of the field data.
            /// </summary>
            /// <value>
            ///     The length.
            /// </value>
            public override ushort Length
            {
                get { return 2; }
            }

            /// <summary>
            ///     Hop set
            /// </summary>
            public byte ChannelHoppingSet { get; set; }

            /// <summary>
            ///     Hop pattern
            /// </summary>
            public byte Pattern { get; set; }

            /// <summary>
            ///     Copies the field data to the destination buffer at the specified offset.
            /// </summary>
            public override void CopyTo(byte[] dest, int offset)
            {
                dest[offset] = this.ChannelHoppingSet;
                dest[offset + 1] = this.Pattern;
            }

            /// <summary>
            ///     ToString() override
            /// </summary>
            /// <returns>
            ///     A <see cref="System.String" />
            /// </returns>
            public override string ToString() { return string.Format("ChannelHoppingSet {0}, Pattern {1}", this.ChannelHoppingSet, this.Pattern); }
        }

        /// <summary>
        ///     Radio tap flags
        /// </summary>
        public class FlagsRadioTapField : RadioTapField
        {
            /// <summary>
            ///     Flags set
            /// </summary>
            public RadioTapFlags Flags;

            /// <summary>
            ///     Constructor
            /// </summary>
            /// <param name="br">
            ///     A <see cref="BinaryReader" />
            /// </param>
            public FlagsRadioTapField(BinaryReader br)
            {
                var u8 = br.ReadByte();
                this.Flags = (RadioTapFlags) u8;
            }

            /// <summary>
            ///     Initializes a new instance of the <see cref="FlagsRadioTapField" /> class.
            /// </summary>
            public FlagsRadioTapField() { }

            /// <summary>
            ///     Initializes a new instance of the <see cref="FlagsRadioTapField" /> class.
            /// </summary>
            /// <param name='Flags'>
            ///     Flags.
            /// </param>
            public FlagsRadioTapField(RadioTapFlags Flags) { this.Flags = Flags; }

            /// <summary>Type of the field</summary>
            public override RadioTapType FieldType
            {
                get { return RadioTapType.Flags; }
            }

            /// <summary>
            ///     Gets the length of the field data.
            /// </summary>
            /// <value>
            ///     The length.
            /// </value>
            public override ushort Length
            {
                get { return 1; }
            }

            /// <summary>
            ///     Copies the field data to the destination buffer at the specified offset.
            /// </summary>
            public override void CopyTo(byte[] dest, int offset) { dest[offset] = (byte) this.Flags; }

            /// <summary>
            ///     ToString() override
            /// </summary>
            /// <returns>
            ///     A <see cref="System.String" />
            /// </returns>
            public override string ToString() { return string.Format("Flags {0}", this.Flags); }
        }

        /// <summary>
        ///     Rate field
        /// </summary>
        public class RateRadioTapField : RadioTapField
        {
            /// <summary>
            ///     Constructor
            /// </summary>
            /// <param name="br">
            ///     A <see cref="BinaryReader" />
            /// </param>
            public RateRadioTapField(BinaryReader br)
            {
                var u8 = br.ReadByte();
                this.RateMbps = (0.5*(u8&0x7f));
            }

            /// <summary>
            ///     Initializes a new instance of the <see cref="RateRadioTapField" /> class.
            /// </summary>
            public RateRadioTapField() { }

            /// <summary>
            ///     Initializes a new instance of the <see cref="RateRadioTapField" /> class.
            /// </summary>
            /// <param name='RateMbps'>
            ///     Rate mbps.
            /// </param>
            public RateRadioTapField(double RateMbps) { this.RateMbps = RateMbps; }

            /// <summary>Type of the field</summary>
            public override RadioTapType FieldType
            {
                get { return RadioTapType.Rate; }
            }

            /// <summary>
            ///     Gets the length of the field data.
            /// </summary>
            /// <value>
            ///     The length.
            /// </value>
            public override ushort Length
            {
                get { return 1; }
            }

            /// <summary>
            ///     Rate in Mbps
            /// </summary>
            public double RateMbps { get; set; }

            /// <summary>
            ///     Copies the field data to the destination buffer at the specified offset.
            /// </summary>
            public override void CopyTo(byte[] dest, int offset) { dest[offset] = (byte) (this.RateMbps/0.5); }

            /// <summary>
            ///     ToString() override
            /// </summary>
            /// <returns>
            ///     A <see cref="System.String" />
            /// </returns>
            public override string ToString() { return string.Format("RateMbps {0}", this.RateMbps); }
        }

        /// <summary>
        ///     Db antenna signal
        /// </summary>
        public class DbAntennaSignalRadioTapField : RadioTapField
        {
            /// <summary>
            ///     Constructor
            /// </summary>
            /// <param name="br">
            ///     A <see cref="BinaryReader" />
            /// </param>
            public DbAntennaSignalRadioTapField(BinaryReader br) { this.SignalStrengthdB = br.ReadByte(); }

            /// <summary>
            ///     Initializes a new instance of the <see cref="DbAntennaSignalRadioTapField" /> class.
            /// </summary>
            public DbAntennaSignalRadioTapField() { }

            /// <summary>
            ///     Initializes a new instance of the <see cref="DbAntennaSignalRadioTapField" /> class.
            /// </summary>
            /// <param name='SignalStrengthdB'>
            ///     Signal strength in dB
            /// </param>
            public DbAntennaSignalRadioTapField(byte SignalStrengthdB) { this.SignalStrengthdB = SignalStrengthdB; }

            /// <summary>Type of the field</summary>
            public override RadioTapType FieldType
            {
                get { return RadioTapType.DbAntennaSignal; }
            }

            /// <summary>
            ///     Gets the length of the field data.
            /// </summary>
            /// <value>
            ///     The length.
            /// </value>
            public override ushort Length
            {
                get { return 1; }
            }

            /// <summary>
            ///     Signal strength in dB
            /// </summary>
            public byte SignalStrengthdB { get; set; }

            /// <summary>
            ///     Copies the field data to the destination buffer at the specified offset.
            /// </summary>
            public override void CopyTo(byte[] dest, int offset) { dest[offset] = this.SignalStrengthdB; }

            /// <summary>
            ///     ToString() override
            /// </summary>
            /// <returns>
            ///     A <see cref="System.String" />
            /// </returns>
            public override string ToString() { return string.Format("SignalStrengthdB {0}", this.SignalStrengthdB); }
        }

        /// <summary>
        ///     Antenna noise in dB
        /// </summary>
        public class DbAntennaNoiseRadioTapField : RadioTapField
        {
            /// <summary>
            ///     Constructor
            /// </summary>
            /// <param name="br">
            ///     A <see cref="BinaryReader" />
            /// </param>
            public DbAntennaNoiseRadioTapField(BinaryReader br) { this.AntennaNoisedB = br.ReadByte(); }

            /// <summary>
            ///     Initializes a new instance of the <see cref="DbAntennaNoiseRadioTapField" /> class.
            /// </summary>
            public DbAntennaNoiseRadioTapField() { }

            /// <summary>
            ///     Initializes a new instance of the <see cref="DbAntennaNoiseRadioTapField" /> class.
            /// </summary>
            /// <param name='AntennaNoisedB'>
            ///     Antenna signal noise in dB.
            /// </param>
            public DbAntennaNoiseRadioTapField(byte AntennaNoisedB) { this.AntennaNoisedB = AntennaNoisedB; }

            /// <summary>Type of the field</summary>
            public override RadioTapType FieldType
            {
                get { return RadioTapType.DbAntennaNoise; }
            }

            /// <summary>
            ///     Gets the length of the field data.
            /// </summary>
            /// <value>
            ///     The length.
            /// </value>
            public override ushort Length
            {
                get { return 1; }
            }

            /// <summary>
            ///     Antenna noise in dB
            /// </summary>
            public byte AntennaNoisedB { get; set; }

            /// <summary>
            ///     Copies the field data to the destination buffer at the specified offset.
            /// </summary>
            public override void CopyTo(byte[] dest, int offset) { dest[offset] = this.AntennaNoisedB; }

            /// <summary>
            ///     ToString() override
            /// </summary>
            /// <returns>
            ///     A <see cref="System.String" />
            /// </returns>
            public override string ToString() { return string.Format("AntennaNoisedB {0}", this.AntennaNoisedB); }
        }

        /// <summary>
        ///     Antenna field
        /// </summary>
        public class AntennaRadioTapField : RadioTapField
        {
            /// <summary>
            ///     Constructor
            /// </summary>
            /// <param name="br">
            ///     A <see cref="BinaryReader" />
            /// </param>
            public AntennaRadioTapField(BinaryReader br) { this.Antenna = br.ReadByte(); }

            /// <summary>
            ///     Initializes a new instance of the <see cref="AntennaRadioTapField" /> class.
            /// </summary>
            public AntennaRadioTapField() { }

            /// <summary>
            ///     Initializes a new instance of the <see cref="AntennaRadioTapField" /> class.
            /// </summary>
            /// <param name='Antenna'>
            ///     Antenna index of the Rx/Tx antenna for this packet. The first antenna is antenna 0.
            /// </param>
            public AntennaRadioTapField(byte Antenna) { this.Antenna = Antenna; }

            /// <summary>Type of the field</summary>
            public override RadioTapType FieldType
            {
                get { return RadioTapType.Antenna; }
            }

            /// <summary>
            ///     Gets the length of the field data.
            /// </summary>
            /// <value>
            ///     The length.
            /// </value>
            public override ushort Length
            {
                get { return 1; }
            }

            /// <summary>
            ///     Antenna number
            /// </summary>
            public byte Antenna { get; set; }

            /// <summary>
            ///     Copies the field data to the destination buffer at the specified offset.
            /// </summary>
            public override void CopyTo(byte[] dest, int offset) { dest[offset] = this.Antenna; }

            /// <summary>
            ///     ToString() override
            /// </summary>
            /// <returns>
            ///     A <see cref="System.String" />
            /// </returns>
            public override string ToString() { return string.Format("Antenna {0}", this.Antenna); }
        }

        /// <summary>
        ///     Antenna signal in dBm
        /// </summary>
        public class DbmAntennaSignalRadioTapField : RadioTapField
        {
            /// <summary>
            ///     Constructor
            /// </summary>
            /// <param name="br">
            ///     A <see cref="BinaryReader" />
            /// </param>
            public DbmAntennaSignalRadioTapField(BinaryReader br) { this.AntennaSignalDbm = br.ReadSByte(); }

            /// <summary>
            ///     Initializes a new instance of the <see cref="DbmAntennaSignalRadioTapField" /> class.
            /// </summary>
            public DbmAntennaSignalRadioTapField() { }

            /// <summary>
            ///     Initializes a new instance of the <see cref="DbmAntennaSignalRadioTapField" /> class.
            /// </summary>
            /// <param name='AntennaSignalDbm'>
            ///     Antenna signal power in dB.
            /// </param>
            public DbmAntennaSignalRadioTapField(sbyte AntennaSignalDbm) { this.AntennaSignalDbm = AntennaSignalDbm; }

            /// <summary>Type of the field</summary>
            public override RadioTapType FieldType
            {
                get { return RadioTapType.DbmAntennaSignal; }
            }

            /// <summary>
            ///     Gets the length of the field data.
            /// </summary>
            /// <value>
            ///     The length.
            /// </value>
            public override ushort Length
            {
                get { return 1; }
            }

            /// <summary>
            ///     Antenna signal in dBm
            /// </summary>
            public sbyte AntennaSignalDbm { get; set; }

            /// <summary>
            ///     Copies the field data to the destination buffer at the specified offset.
            /// </summary>
            public override void CopyTo(byte[] dest, int offset) { dest[offset] = (byte) this.AntennaSignalDbm; }

            /// <summary>
            ///     ToString() override
            /// </summary>
            /// <returns>
            ///     A <see cref="System.String" />
            /// </returns>
            public override string ToString() { return string.Format("AntennaSignalDbm {0}", this.AntennaSignalDbm); }
        }

        /// <summary>
        ///     Antenna noise in dBm
        /// </summary>
        public class DbmAntennaNoiseRadioTapField : RadioTapField
        {
            /// <summary>
            ///     Constructor
            /// </summary>
            /// <param name="br">
            ///     A <see cref="BinaryReader" />
            /// </param>
            public DbmAntennaNoiseRadioTapField(BinaryReader br) { this.AntennaNoisedBm = br.ReadSByte(); }

            /// <summary>
            ///     Initializes a new instance of the <see cref="DbmAntennaNoiseRadioTapField" /> class.
            /// </summary>
            public DbmAntennaNoiseRadioTapField() { }

            /// <summary>
            ///     Initializes a new instance of the <see cref="DbmAntennaNoiseRadioTapField" /> class.
            /// </summary>
            /// <param name='AntennaNoisedBm'>
            ///     Antenna noise in dBm.
            /// </param>
            public DbmAntennaNoiseRadioTapField(sbyte AntennaNoisedBm) { this.AntennaNoisedBm = AntennaNoisedBm; }

            /// <summary>Type of the field</summary>
            public override RadioTapType FieldType
            {
                get { return RadioTapType.DbmAntennaNoise; }
            }

            /// <summary>
            ///     Gets the length of the field data.
            /// </summary>
            /// <value>
            ///     The length.
            /// </value>
            public override ushort Length
            {
                get { return 1; }
            }

            /// <summary>
            ///     Antenna noise in dBm
            /// </summary>
            public sbyte AntennaNoisedBm { get; set; }

            /// <summary>
            ///     Copies the field data to the destination buffer at the specified offset.
            /// </summary>
            public override void CopyTo(byte[] dest, int offset) { dest[offset] = (byte) this.AntennaNoisedBm; }

            /// <summary>
            ///     ToString() override
            /// </summary>
            /// <returns>
            ///     A <see cref="System.String" />
            /// </returns>
            public override string ToString() { return string.Format("AntennaNoisedBm {0}", this.AntennaNoisedBm); }
        }

        /// <summary>
        ///     Lock quality
        /// </summary>
        public class LockQualityRadioTapField : RadioTapField
        {
            /// <summary>
            ///     Constructor
            /// </summary>
            /// <param name="br">
            ///     A <see cref="BinaryReader" />
            /// </param>
            public LockQualityRadioTapField(BinaryReader br) { this.SignalQuality = br.ReadUInt16(); }

            /// <summary>
            ///     Initializes a new instance of the <see cref="LockQualityRadioTapField" /> class.
            /// </summary>
            public LockQualityRadioTapField() { }

            /// <summary>
            ///     Initializes a new instance of the <see cref="LockQualityRadioTapField" /> class.
            /// </summary>
            /// <param name='SignalQuality'>
            ///     Signal quality.
            /// </param>
            public LockQualityRadioTapField(UInt16 SignalQuality) { this.SignalQuality = SignalQuality; }

            /// <summary>Type of the field</summary>
            public override RadioTapType FieldType
            {
                get { return RadioTapType.LockQuality; }
            }

            /// <summary>
            ///     Gets the length of the field data.
            /// </summary>
            /// <value>
            ///     The length.
            /// </value>
            public override ushort Length
            {
                get { return 2; }
            }

            /// <summary>
            ///     Signal quality
            /// </summary>
            public UInt16 SignalQuality { get; set; }

            /// <summary>
            ///     Copies the field data to the destination buffer at the specified offset.
            /// </summary>
            public override void CopyTo(byte[] dest, int offset) { EndianBitConverter.Little.CopyBytes(this.SignalQuality, dest, offset); }

            /// <summary>
            ///     ToString() override
            /// </summary>
            /// <returns>
            ///     A <see cref="System.String" />
            /// </returns>
            public override string ToString() { return string.Format("SignalQuality {0}", this.SignalQuality); }
        }

        /// <summary>
        ///     Tsft radio tap field
        /// </summary>
        public class TsftRadioTapField : RadioTapField
        {
            /// <summary>
            ///     Constructor
            /// </summary>
            /// <param name="br">
            ///     A <see cref="BinaryReader" />
            /// </param>
            public TsftRadioTapField(BinaryReader br) { this.TimestampUsec = br.ReadUInt64(); }

            /// <summary>
            ///     Initializes a new instance of the <see cref="TsftRadioTapField" /> class.
            /// </summary>
            public TsftRadioTapField() { }

            /// <summary>
            ///     Initializes a new instance of the <see cref="TsftRadioTapField" /> class.
            /// </summary>
            /// <param name='TimestampUsec'>
            ///     Value in microseconds of the Time Synchronization Function timer
            /// </param>
            public TsftRadioTapField(UInt64 TimestampUsec) { this.TimestampUsec = TimestampUsec; }

            /// <summary>Type of the field</summary>
            public override RadioTapType FieldType
            {
                get { return RadioTapType.Tsft; }
            }

            /// <summary>
            ///     Gets the length of the field data.
            /// </summary>
            /// <value>
            ///     The length.
            /// </value>
            public override ushort Length
            {
                get { return 8; }
            }

            /// <summary>
            ///     Timestamp in microseconds
            /// </summary>
            public UInt64 TimestampUsec { get; set; }

            /// <summary>
            ///     Copies the field data to the destination buffer at the specified offset.
            /// </summary>
            public override void CopyTo(byte[] dest, int offset) { EndianBitConverter.Little.CopyBytes(this.TimestampUsec, dest, offset); }

            /// <summary>
            ///     ToString() override
            /// </summary>
            /// <returns>
            ///     A <see cref="System.String" />
            /// </returns>
            public override string ToString() { return string.Format("TimestampUsec {0}", this.TimestampUsec); }
        }

        /// <summary>
        ///     Contains properties about the received from.
        /// </summary>
        public class RxFlagsRadioTapField : RadioTapField
        {
            /// <summary>
            ///     Constructor
            /// </summary>
            /// <param name="br">
            ///     A <see cref="BinaryReader" />
            /// </param>
            public RxFlagsRadioTapField(BinaryReader br)
            {
                var flags = br.ReadUInt16();
                Console.WriteLine("RxFlagsRadioTapField {0}", flags);
                this.PlcpCrcCheckFailed = ((flags&0x2) == 0x2);
            }

            /// <summary>
            ///     Initializes a new instance of the <see cref="RxFlagsRadioTapField" /> class.
            /// </summary>
            public RxFlagsRadioTapField() { }

            /// <summary>
            ///     Initializes a new instance of the <see cref="RxFlagsRadioTapField" /> class.
            /// </summary>
            /// <param name='PlcpCrcCheckFailed'>
            ///     PLCP CRC check failed.
            /// </param>
            public RxFlagsRadioTapField(bool PlcpCrcCheckFailed) { this.PlcpCrcCheckFailed = PlcpCrcCheckFailed; }

            /// <summary>Type of the field</summary>
            public override RadioTapType FieldType
            {
                get { return RadioTapType.RxFlags; }
            }

            /// <summary>
            ///     Gets the length of the field data.
            /// </summary>
            /// <value>
            ///     The length.
            /// </value>
            public override ushort Length
            {
                get { return 2; }
            }

            /// <summary>
            ///     Gets or sets a value indicating whether the frame failed the PLCP CRC check.
            /// </summary>
            /// <value>
            ///     <c>true</c> if the PLCP CRC check failed; otherwise, <c>false</c>.
            /// </value>
            public bool PlcpCrcCheckFailed { get; set; }

            /// <summary>
            ///     Copies the field data to the destination buffer at the specified offset.
            /// </summary>
            public override void CopyTo(byte[] dest, int offset)
            {
                var flags = (UInt16) ((this.PlcpCrcCheckFailed)? 0x2 : 0x0);
                EndianBitConverter.Little.CopyBytes(flags, dest, offset);
            }

            /// <summary>
            ///     ToString() override
            /// </summary>
            /// <returns>
            ///     A <see cref="System.String" />
            /// </returns>
            public override string ToString() { return string.Format("PlcpCrcCheckFailed {0}", this.PlcpCrcCheckFailed); }
        }

        /// <summary>
        ///     Transmit power expressed as unitless distance from max
        ///     power set at factory calibration.  0 is max power.
        ///     Monotonically nondecreasing with lower power levels.
        /// </summary>
        public class TxAttenuationRadioTapField : RadioTapField
        {
            /// <summary>
            ///     Constructor
            /// </summary>
            /// <param name="br">
            ///     A <see cref="BinaryReader" />
            /// </param>
            public TxAttenuationRadioTapField(BinaryReader br) { this.TxPower = -br.ReadUInt16(); }

            /// <summary>
            ///     Initializes a new instance of the <see cref="TxAttenuationRadioTapField" /> class.
            /// </summary>
            public TxAttenuationRadioTapField() { }

            /// <summary>
            ///     Initializes a new instance of the <see cref="TxAttenuationRadioTapField" /> class.
            /// </summary>
            /// <param name='TxPower'>
            ///     Transmit power expressed as unitless distance from max power set at factory calibration. 0 is max power.
            /// </param>
            public TxAttenuationRadioTapField(int TxPower) { this.TxPower = TxPower; }

            /// <summary>Type of the field</summary>
            public override RadioTapType FieldType
            {
                get { return RadioTapType.TxAttenuation; }
            }

            /// <summary>
            ///     Gets the length of the field data.
            /// </summary>
            /// <value>
            ///     The length.
            /// </value>
            public override ushort Length
            {
                get { return 2; }
            }

            /// <summary>
            ///     Transmit power
            /// </summary>
            public int TxPower { get; set; }

            /// <summary>
            ///     Copies the field data to the destination buffer at the specified offset.
            /// </summary>
            public override void CopyTo(byte[] dest, int offset)
            {
                var absValue = (UInt16) Math.Abs(this.TxPower);
                EndianBitConverter.Little.CopyBytes(absValue, dest, offset);
            }

            /// <summary>
            ///     ToString() override
            /// </summary>
            /// <returns>
            ///     A <see cref="System.String" />
            /// </returns>
            public override string ToString() { return string.Format("TxPower {0}", this.TxPower); }
        }

        /// <summary>
        ///     Transmit power expressed as decibel distance from max power
        ///     set at factory calibration.  0 is max power.  Monotonically
        ///     nondecreasing with lower power levels.
        /// </summary>
        public class DbTxAttenuationRadioTapField : RadioTapField
        {
            /// <summary>
            ///     Constructor
            /// </summary>
            /// <param name="br">
            ///     A <see cref="BinaryReader" />
            /// </param>
            public DbTxAttenuationRadioTapField(BinaryReader br) { this.TxPowerdB = -br.ReadUInt16(); }

            /// <summary>
            ///     Initializes a new instance of the <see cref="DbTxAttenuationRadioTapField" /> class.
            /// </summary>
            public DbTxAttenuationRadioTapField() { }

            /// <summary>
            ///     Initializes a new instance of the <see cref="DbTxAttenuationRadioTapField" /> class.
            /// </summary>
            /// <param name='TxPowerdB'>
            ///     Transmit power expressed as decibel distance from max power set at factory calibration. 0 is max power.
            /// </param>
            public DbTxAttenuationRadioTapField(int TxPowerdB) { this.TxPowerdB = TxPowerdB; }

            /// <summary>Type of the field</summary>
            public override RadioTapType FieldType
            {
                get { return RadioTapType.DbTxAttenuation; }
            }

            /// <summary>
            ///     Gets the length of the field data.
            /// </summary>
            /// <value>
            ///     The length.
            /// </value>
            public override ushort Length
            {
                get { return 2; }
            }

            /// <summary>
            ///     Transmit power
            /// </summary>
            public int TxPowerdB { get; set; }

            /// <summary>
            ///     Copies the field data to the destination buffer at the specified offset.
            /// </summary>
            public override void CopyTo(byte[] dest, int offset)
            {
                var absValue = (UInt16) Math.Abs(this.TxPowerdB);
                EndianBitConverter.Little.CopyBytes(absValue, dest, offset);
            }

            /// <summary>
            ///     ToString() override
            /// </summary>
            /// <returns>
            ///     A <see cref="System.String" />
            /// </returns>
            public override string ToString() { return string.Format("TxPowerdB {0}", this.TxPowerdB); }
        }

        /// <summary>
        ///     Transmit power expressed as dBm (decibels from a 1 milliwatt
        ///     reference). This is the absolute power level measured at
        ///     the antenna port.
        /// </summary>
        public class DbmTxPowerRadioTapField : RadioTapField
        {
            /// <summary>
            ///     Constructor
            /// </summary>
            /// <param name="br">
            ///     A <see cref="BinaryReader" />
            /// </param>
            public DbmTxPowerRadioTapField(BinaryReader br) { this.TxPowerdBm = br.ReadSByte(); }

            /// <summary>
            ///     Initializes a new instance of the <see cref="DbmTxPowerRadioTapField" /> class.
            /// </summary>
            public DbmTxPowerRadioTapField() { }

            /// <summary>
            ///     Initializes a new instance of the <see cref="DbmTxPowerRadioTapField" /> class.
            /// </summary>
            /// <param name='TxPowerdBm'>
            ///     Transmit power expressed as dBm (decibels from a 1 milliwatt reference).
            /// </param>
            public DbmTxPowerRadioTapField(sbyte TxPowerdBm) { this.TxPowerdBm = TxPowerdBm; }

            /// <summary>Type of the field</summary>
            public override RadioTapType FieldType
            {
                get { return RadioTapType.DbmTxPower; }
            }

            /// <summary>
            ///     Gets the length of the field data.
            /// </summary>
            /// <value>
            ///     The length.
            /// </value>
            public override ushort Length
            {
                get { return 1; }
            }

            /// <summary>
            ///     Tx power in dBm
            /// </summary>
            public sbyte TxPowerdBm { get; set; }

            /// <summary>
            ///     Copies the field data to the destination buffer at the specified offset.
            /// </summary>
            public override void CopyTo(byte[] dest, int offset) { dest[offset] = (byte) this.TxPowerdBm; }

            /// <summary>
            ///     ToString() override
            /// </summary>
            /// <returns>
            ///     A <see cref="System.String" />
            /// </returns>
            public override string ToString() { return string.Format("TxPowerdBm {0}", this.TxPowerdBm); }
        }

        /// <summary>
        ///     Abstract class for all radio tap fields
        /// </summary>
        public abstract class RadioTapField
        {
            /// <summary>Type of the field</summary>
            public abstract RadioTapType FieldType { get; }

            /// <summary>
            ///     Gets the length of the field data.
            /// </summary>
            /// <value>
            ///     The length.
            /// </value>
            public abstract ushort Length { get; }

            /// <summary>
            ///     Copies the field data to the destination buffer at the specified offset.
            /// </summary>
            public abstract void CopyTo(byte[] dest, int offset);

            /// <summary>
            ///     Parse a radio tap field, indicated by bitIndex, from a given BinaryReader
            /// </summary>
            /// <param name="bitIndex">
            ///     A <see cref="System.Int32" />
            /// </param>
            /// <param name="br">
            ///     A <see cref="BinaryReader" />
            /// </param>
            /// <returns>
            ///     A <see cref="RadioTapField" />
            /// </returns>
            public static RadioTapField Parse(int bitIndex, BinaryReader br)
            {
                var Type = (RadioTapType) bitIndex;
                switch(Type)
                {
                    case RadioTapType.Flags:
                        return new FlagsRadioTapField(br);
                    case RadioTapType.Rate:
                        return new RateRadioTapField(br);
                    case RadioTapType.DbAntennaSignal:
                        return new DbAntennaSignalRadioTapField(br);
                    case RadioTapType.DbAntennaNoise:
                        return new DbAntennaNoiseRadioTapField(br);
                    case RadioTapType.Antenna:
                        return new AntennaRadioTapField(br);
                    case RadioTapType.DbmAntennaSignal:
                        return new DbmAntennaSignalRadioTapField(br);
                    case RadioTapType.DbmAntennaNoise:
                        return new DbmAntennaNoiseRadioTapField(br);
                    case RadioTapType.Channel:
                        return new ChannelRadioTapField(br);
                    case RadioTapType.Fhss:
                        return new FhssRadioTapField(br);
                    case RadioTapType.LockQuality:
                        return new LockQualityRadioTapField(br);
                    case RadioTapType.TxAttenuation:
                        return new TxAttenuationRadioTapField(br);
                    case RadioTapType.DbTxAttenuation:
                        return new DbTxAttenuationRadioTapField(br);
                    case RadioTapType.DbmTxPower:
                        return new DbmTxPowerRadioTapField(br);
                    case RadioTapType.Tsft:
                        return new TsftRadioTapField(br);
                    case RadioTapType.RxFlags:
                        return new RxFlagsRadioTapField(br);
                    default:
                        //the RadioTap fields are extendable so there may be some we dont know about
                        return null;
                }
            }
        };
    }
}