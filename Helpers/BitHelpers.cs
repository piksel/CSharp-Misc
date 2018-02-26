namespace Piksel.Helpers
{

    // Note: MSB vs LSB is used to refer to what the first bit refers to
    // So bit 0 in LSB: 00000001
    //          in MSB: 10000000
    // MSB is used for the flag packer.

    public static class BitHelpers
    {
        public const byte Bit0L = 1 << 0;
        public const byte Bit1L = 1 << 1;
        public const byte Bit2L = 1 << 2;
        public const byte Bit3L = 1 << 3;
        public const byte Bit4L = 1 << 4;
        public const byte Bit5L = 1 << 5;
        public const byte Bit6L = 1 << 6;
        public const byte Bit7L = 1 << 7;

        public const byte Bit0M = 1 << 7;
        public const byte Bit1M = 1 << 6;
        public const byte Bit2M = 1 << 5;
        public const byte Bit3M = 1 << 4;
        public const byte Bit4M = 1 << 3;
        public const byte Bit5M = 1 << 2;
        public const byte Bit6M = 1 << 1;
        public const byte Bit7M = 1 << 0;

        public static byte PackFlags(params bool[] flags)
        {
            byte b = 0;
            for (int i = 0; i < 8; i++)
            {
                if (flags.Length <= i) break;
                if (flags[i])
                {
                    b |= (byte)(0x80 >> i);
                }
                else
                {
                    b ^= (byte)(0x80 >> i);
                }
            }
            return b;
        }

        // Comment out this if you dont use System.ValueTuple
        // (Or install it with: Install-Package System.ValueTuple)
        public static (bool, bool, bool, bool, bool, bool, bool, bool) UnpackFlags(byte packed)
            => (BitSetM(packed, 0), BitSetM(packed, 1), BitSetM(packed, 2), BitSetM(packed, 3),
                BitSetM(packed, 4), BitSetM(packed, 5), BitSetM(packed, 6), BitSetM(packed, 7));

        public static bool BitSet(byte value, byte bit)
        {
            return (value & bit) == bit;
        }

        public static bool BitSetL(byte value, int bitNumber)
        {
            return BitSet(value, (byte)(1 << bitNumber));
        }

        public static bool BitSetM(byte value, int bitNumber)
        {
            return BitSetL(value, (byte)(0x80 >> bitNumber));
        }
    }
}
