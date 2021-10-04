using System.Globalization;
using System.IO;

namespace NCodeManager
{
    static class Helpers
    {
        public static bool HexStringToUInt(string hex, out uint val)
        {
            return uint.TryParse(hex, NumberStyles.HexNumber, null, out val);
        }

        public static uint ReadUIntSwappedEndianness(BinaryReader binaryReader)
        {
            uint val = binaryReader.ReadUInt32();
            val = (val >> 16) | (val << 16);
            val = ((val & 0xFF00FF00) >> 8) | ((val & 0x00FF00FF) << 8);
            return val;
        }

        public static void WriteUIntSwappedEndianness(BinaryWriter binaryWriter, uint val)
        {
            val = (val >> 16) | (val << 16);
            val = ((val & 0xFF00FF00) >> 8) | ((val & 0x00FF00FF) << 8);
            binaryWriter.Write(val);
        }
    }
}
