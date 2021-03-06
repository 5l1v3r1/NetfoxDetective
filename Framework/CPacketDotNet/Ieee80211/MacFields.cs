﻿namespace PacketDotNet.Ieee80211
{
    namespace Ieee80211
    {
        /// <summary>
        ///     NOTE: All positions are not defined here because the frame type changes
        ///     whether some address fields are present or not, causing the sequence control
        ///     field to move. In addition the payload size determines where the frame control
        ///     sequence value is as it is after the payload bytes, if any payload is present
        /// </summary>
        internal class MacFields
        {
            public static readonly int FrameControlLength = 2;
            public static readonly int DurationIDLength = 2;
            public static readonly int AddressLength = EthernetFields.MacAddressLength;
            public static readonly int SequenceControlLength = 2;
            public static readonly int FrameCheckSequenceLength = 4;
            public static readonly int FrameControlPosition = 0;
            public static readonly int DurationIDPosition;

            /// <summary>
            ///     Not all MAC Frames contain a sequence control field. The value of this field is only meaningful when they do.
            /// </summary>
            public static readonly int SequenceControlPosition;

            public static readonly int Address1Position;

            static MacFields()
            {
                DurationIDPosition = FrameControlPosition + FrameControlLength;
                Address1Position = DurationIDPosition + DurationIDLength;
                SequenceControlPosition = Address1Position + (AddressLength*3);
            }
        }
    }
}