using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using static NCodeManager.Helpers;

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

        public void Parse(string instructionsString)
        {
            Instructions.Clear();
            
            var stringReader = new StringReader(instructionsString);
            int lineNumber = 1;
            while (true)
            {
                string line = stringReader.ReadLine();
                if (line == null)
                    break;

                if (line == string.Empty)
                    continue;

                string[] instruction = line.Split(' ');
                if (instruction.Length != 2)
                    throw new Exception(string.Format("Bad syntax (line #{0})", lineNumber));

                uint address;
                uint data;
                if (!HexStringToUInt(instruction[0], out address) || !HexStringToUInt(instruction[1], out data))
                    throw new Exception(string.Format("Input is not hexadecimal (line #{0})", lineNumber));

                Instructions.Add((address, data));

                ++lineNumber;
            }
        }

        public void Parse(Stream stream)
        {
            Instructions.Clear();

            var binaryReader = new BinaryReader(stream);

            if (stream.Length == 0 || stream.Length % 8 != 0)
                throw new Exception("Bad size");

            if (ReadUIntSwappedEndianness(binaryReader) != 0x00D0C0DE || 
                ReadUIntSwappedEndianness(binaryReader) != 0x00D0C0DE)
                throw new Exception("Missing start instruction");

            bool endFound = false;
            while (stream.Position != stream.Length)
            {
                uint address = ReadUIntSwappedEndianness(binaryReader);
                uint data = ReadUIntSwappedEndianness(binaryReader);

                if (address == 0xF0000000 && data == 0x00000000)
                {
                    endFound = true;
                    break;
                }

                Instructions.Add((address, data));
            }

            if (!endFound)
                throw new Exception("Missing end instruction");
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
