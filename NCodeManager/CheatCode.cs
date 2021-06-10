using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;

namespace NCodeManager
{
    class CheatCode
    {
        public string Name;

        public List<(uint, uint)> Instructions = new List<(uint, uint)>();

        public override string ToString()
        {
            return Name;
        }

        public CheatCode(string name = "New Code")
        {
            Name = name;
        }

        public CheatCode(string name, Stream data)
        {
            Name = name;
            Parse(data);
        }

        public string InstructionsAsString()
        {
            string instructionsString = string.Empty;

            foreach ((uint, uint) instruction in Instructions)
                instructionsString += string.Format("{0:X8} {1:X8}\r\n", instruction.Item1, instruction.Item2);

            return instructionsString;
        }

        private static bool HexStringToUInt(string hex, out uint val)
        {
            return uint.TryParse(hex, NumberStyles.HexNumber, null, out val);
        }

        private static uint ReadUIntSwappedEndianness(BinaryReader binaryReader)
        {
            uint val = binaryReader.ReadUInt32();
            val = (val >> 16) | (val << 16);
            val = ((val & 0xFF00FF00) >> 8) | ((val & 0x00FF00FF) << 8);
            return val;
        }

        private static void WriteUIntSwappedEndianness(BinaryWriter binaryWriter, uint val)
        {
            val = (val >> 16) | (val << 16);
            val = ((val & 0xFF00FF00) >> 8) | ((val & 0x00FF00FF) << 8);
            binaryWriter.Write(val);
        }

        public void Parse(string instructionsString)
        {
            Instructions.Clear();

            var stringReader = new StringReader(instructionsString);
            while (true)
            {
                string line = stringReader.ReadLine();
                if (line == null)
                    break;

                if (line == string.Empty)
                    continue;

                string[] instruction = line.Split(' ');
                if (instruction.Length != 2)
                    throw new Exception("Invalid code");

                uint address;
                uint data;
                if (!HexStringToUInt(instruction[0], out address) || !HexStringToUInt(instruction[1], out data))
                    throw new Exception("Invalid code");

                Instructions.Add((address, data));
            }
        }

        public void Parse(Stream stream)
        {
            Instructions.Clear();

            var binaryReader = new BinaryReader(stream);

            if (stream.Length < 8)
                throw new Exception("Could not read GCT");

            if (ReadUIntSwappedEndianness(binaryReader) != 0x00D0C0DE || 
                ReadUIntSwappedEndianness(binaryReader) != 0x00D0C0DE)
                throw new Exception("Could not read GCT");

            while (stream.Length - stream.Position >= 8)
            {
                uint address = ReadUIntSwappedEndianness(binaryReader);
                uint data = ReadUIntSwappedEndianness(binaryReader);

                if (address == 0xF0000000 && data == 0x00000000)
                    break;

                Instructions.Add((address, data));
            }
        }

        public static void WriteGCT(Stream stream, CheckedListBox.CheckedItemCollection codesList)
        {
            var binaryWriter = new BinaryWriter(stream);

            WriteUIntSwappedEndianness(binaryWriter, 0x00D0C0DE);
            WriteUIntSwappedEndianness(binaryWriter, 0x00D0C0DE);

            foreach (CheatCode cheatCode in codesList)
            {
                foreach ((uint, uint) instruction in cheatCode.Instructions)
                {
                    WriteUIntSwappedEndianness(binaryWriter, instruction.Item1);
                    WriteUIntSwappedEndianness(binaryWriter, instruction.Item2);
                }
            }

            WriteUIntSwappedEndianness(binaryWriter, 0xF0000000);
            WriteUIntSwappedEndianness(binaryWriter, 0x00000000);
        }
    }
}
