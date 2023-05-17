using System;
using System.IO;
using System.Text;

namespace TOTK_SaveGame_Editor
{
    public class SaveFile
    {
        public bool IsLoaded = false;

        internal string _Path = "progress.sav";
        internal byte[] _Data;
        
        public void PatchSaveFile()
        {
            File.WriteAllBytes(_Path, _Data);
        }

        public void CreateBackup()
        {
            File.Copy(_Path, _Path + ".backup", true);
        }

        public int FindBytePatternOffset(byte[] pattern)
        {
            for (int i = 0; i <= _Data.Length - pattern.Length; i++)
            {
                bool match = true;

                for (int j = 0; j < pattern.Length; j++)
                {
                    if (_Data[i + j] != pattern[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    return i + pattern.Length;
                }
            }
            return -1;
        }

        // Read/Write
        public bool ReadBool(int offset)
        {
            return BitConverter.ToBoolean(_Data, offset);
        }

        public void WriteBool(int offset, bool value)
        {
            _Data[offset] = value ? (byte)0x01 : (byte)0x00;
        }

        public int ReadInt(int offset)
        {
            return BitConverter.ToInt32(_Data, offset);
        }

        public void WriteInt(int offset, int value)
        {
            byte[] valueBytes = BitConverter.GetBytes(value);
            Array.Copy(valueBytes, 0, _Data, offset, sizeof(int));
        }

        public float ReadFloat(int offset)
        {
            return BitConverter.ToSingle(_Data, offset);
        }

        public void WriteFloat(int offset, float value)
        {
            byte[] valueBytes = BitConverter.GetBytes(value);
            Array.Copy(valueBytes, 0, _Data, offset, sizeof(float));
        }

        public string ReadString(int offset)
        {
            byte[] stringData = new byte[0x40];
            Array.Copy(_Data, offset, stringData, 0, 0x40);

            return Encoding.UTF8.GetString(stringData).Replace("\x00", ""); ;
        }

        public void WriteString(int offset, string value)
        {
            if (value == "None") return;

            byte[] byteData = new byte[0x40];
            byte[] stringBytes = Encoding.UTF8.GetBytes(value);

            Array.Copy(stringBytes, 0, byteData, 0, Math.Min(stringBytes.Length, byteData.Length));
            Array.Copy(byteData, 0, _Data, offset, 0x40);
        }
    }
}
