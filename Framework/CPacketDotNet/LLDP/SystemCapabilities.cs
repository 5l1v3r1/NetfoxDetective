using PacketDotNet.MiscUtil.Conversion;
using PacketDotNet.Utils;

namespace PacketDotNet.LLDP
{
    /// <summary>
    ///     A System Capabilities TLV
    ///     [TLVTypeLength - 2 bytes][System Capabilities - 2 bytes][Enabled Capabilities - 2 bytes]
    /// </summary>
    public class SystemCapabilities : TLV
    {
        private const int SystemCapabilitiesLength = 2;
        private const int EnabledCapabilitiesLength = 2;

        #region Constructors
        /// <summary>
        ///     Creates a System Capabilities TLV
        /// </summary>
        /// <param name="bytes">
        /// </param>
        /// <param name="offset">
        ///     The System Capabilities TLV's offset from the
        ///     origin of the LLDP
        /// </param>
        public SystemCapabilities(byte[] bytes, int offset) : base(bytes, offset) { }

        /// <summary>
        ///     Creates a System Capabilities TLV and sets the value
        /// </summary>
        /// <param name="capabilities">
        ///     A bitmap containing the available System Capabilities
        /// </param>
        /// <param name="enabled">
        ///     A bitmap containing the enabled System Capabilities
        /// </param>
        public SystemCapabilities(ushort capabilities, ushort enabled)
        {
            var length = TLVTypeLength.TypeLengthLength + SystemCapabilitiesLength + EnabledCapabilitiesLength;
            var bytes = new byte[length];
            var offset = 0;
            this.tlvData = new ByteArraySegment(bytes, offset, length);

            this.Type = TLVTypes.SystemCapabilities;
            this.Capabilities = capabilities;
            this.Enabled = enabled;
        }
        #endregion

        #region Properties
        /// <value>
        ///     A bitmap containing the available System Capabilities
        /// </value>
        public ushort Capabilities
        {
            get
            {
                // get the capabilities
                return EndianBitConverter.Big.ToUInt16(this.tlvData.Bytes, this.tlvData.Offset + TLVTypeLength.TypeLengthLength);
            }
            set
            {
                // set the capabilities
                EndianBitConverter.Big.CopyBytes(value, this.tlvData.Bytes, this.tlvData.Offset + TLVTypeLength.TypeLengthLength);
            }
        }

        /// <value>
        ///     A bitmap containing the Enabled System Capabilities
        /// </value>
        public ushort Enabled
        {
            get { return EndianBitConverter.Big.ToUInt16(this.tlvData.Bytes, this.tlvData.Offset + TLVTypeLength.TypeLengthLength + SystemCapabilitiesLength); }

            set
            {
                // Add the length of the previous field, the SystemCapabilities field, to get
                // to the location of the EnabledCapabilities
                EndianBitConverter.Big.CopyBytes(value, this.tlvData.Bytes, this.ValueOffset + SystemCapabilitiesLength);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        ///     Checks whether the system is capable of a certain function
        /// </summary>
        /// <param name="capability">
        ///     The capability being checked
        /// </param>
        /// <returns>
        ///     Whether or not the system is capable of the function being tested
        /// </returns>
        public bool IsCapable(CapabilityOptions capability)
        {
            var mask = (ushort) capability;
            if((this.Capabilities&mask) != 0) { return true; }
            return false;
        }

        /// <summary>
        ///     Checks whether the specified function has been enabled on the system
        /// </summary>
        /// <param name="capability">
        ///     The capability being checked
        /// </param>
        /// <returns>
        ///     Whether or not the specified function is enabled
        /// </returns>
        public bool IsEnabled(CapabilityOptions capability)
        {
            var mask = (ushort) capability;
            if((this.Enabled&mask) != 0) { return true; }
            return false;
        }

        /// <summary>
        ///     Convert this System Capabilities TLV to a string.
        /// </summary>
        /// <returns>
        ///     A human readable string
        /// </returns>
        public override string ToString() { return string.Format("[SystemCapabilities: Capabilities={0}, Enabled={1}]", this.Capabilities, this.Enabled); }
        #endregion
    }
}