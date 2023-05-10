using System;
using System.IO;
using System.Text;
using TOTK_SaveGame_Editor.Offsets;

namespace TOTK_SaveGame_Editor
{
    public class SaveFile
    {
        public bool IsLoaded = false;

        private string _Path = "progress.sav";
        private byte[] _Data;
        
        private int RUPEE_ADDRESS;              // 0x04 | int32 | Pattern: D7 21 79 A7       
        private int HEART_ADDRESS;              // 0x04 | int32 | Pattern: A1 1D E0 FB      
        private int MAX_HEART_ADDRESS;          // 0x04 | int32 | Pattern: 80 55 AB 31     
        private int STAMINA_ADDRESS;            // 0x04 | float | Pattern: 74 2C 21 F9

        private int SWORD_ADDRESS;
        private int BOW_ADDRESS;
        private int SHIELD_ADDRESS;
        private int ARMOR_ADDRESS;

        private static int SWORD_POUCH_SIZE;
        private static int BOW_POUCH_SIZE;
        private static int SHIELD_POUCH_SIZE;

        public SaveFile(string path)
        {
            if (!File.Exists(path)) return;

            _Path = path;
            _Data = File.ReadAllBytes(_Path);
            IsLoaded = true;

            CreateBackup();

            RUPEE_ADDRESS       = FindBytePatternOffset(new byte[] { 0xD7, 0x21, 0x79, 0xA7 }) + 0x04;
            MAX_HEART_ADDRESS   = FindBytePatternOffset(new byte[] { 0xA1, 0x1D, 0xE0, 0xFB }) + 0x04;
            HEART_ADDRESS       = FindBytePatternOffset(new byte[] { 0x80, 0x55, 0xAB, 0x31 }) + 0x04;
            STAMINA_ADDRESS     = FindBytePatternOffset(new byte[] { 0x74, 0x2C, 0x21, 0xF9 }) + 0x04;
            
            if (_Data.Length == Offsets_1_0_0.FILESIZE)
            {
                SWORD_ADDRESS       = Offsets_1_0_0.SWORD_ADDRESS;
                BOW_ADDRESS         = Offsets_1_0_0.BOW_ADDRESS;
                SHIELD_ADDRESS      = Offsets_1_0_0.SHIELD_ADDRESS;
                ARMOR_ADDRESS       = Offsets_1_0_0.ARMOR_ADDRESS;

                SWORD_POUCH_SIZE    = Offsets_1_0_0.SWORD_POUCH_SIZE;
                BOW_POUCH_SIZE      = Offsets_1_0_0.BOW_POUCH_SIZE;
                SHIELD_POUCH_SIZE   = Offsets_1_0_0.SHIELD_POUCH_SIZE;

                return;
            }

            if(_Data.Length == Offsets_1_1_0.FILESIZE)
            {
                SWORD_ADDRESS       = Offsets_1_1_0.SWORD_ADDRESS;
                BOW_ADDRESS         = Offsets_1_1_0.BOW_ADDRESS;
                SHIELD_ADDRESS      = Offsets_1_1_0.SHIELD_ADDRESS;
                ARMOR_ADDRESS       = Offsets_1_1_0.ARMOR_ADDRESS;

                SWORD_POUCH_SIZE    = Offsets_1_1_0.SWORD_POUCH_SIZE;
                BOW_POUCH_SIZE      = Offsets_1_1_0.BOW_POUCH_SIZE;
                SHIELD_POUCH_SIZE   = Offsets_1_1_0.SHIELD_POUCH_SIZE;

                return;
            }
        }

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
                    return i;
                }
            }
            return -1;
        }

        // Read/Write
        public int ReadInt(int offset)
        {
            return BitConverter.ToInt32(_Data, offset);
        }

        public float ReadFloat(int offset)
        {
            return BitConverter.ToSingle(_Data, offset);
        }

        public void WriteInt(int offset, int value)
        {
            byte[] valueBytes = BitConverter.GetBytes(value);
            Array.Copy(valueBytes, 0, _Data, offset, sizeof(int));
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

        // ReadData
        public int ReadRupees()
        {
            return ReadInt(RUPEE_ADDRESS);
        }

        public int ReadHearts()
        {
            return ReadInt(MAX_HEART_ADDRESS) / 4;
        }

        public int ReadStamina()
        {
            return (int)ReadFloat(STAMINA_ADDRESS);
        }

        public string ReadSword(int slot)
        {
            return ReadString(SWORD_ADDRESS + (slot * 0x40));
        }

        public string ReadBow(int slot)
        {
            return ReadString(BOW_ADDRESS + (slot * 0x40));
        }

        public string ReadShield(int slot)
        {
            return ReadString(SHIELD_ADDRESS + (slot * 0x40));
        }

        public string ReadArmor(int slot)
        {
            return ReadString(ARMOR_ADDRESS + (slot * 0x40));
        }

        public int ReadSwordPouch()
        {
            return ReadInt(SWORD_POUCH_SIZE);
        }

        public int ReadBowPouch()
        {
            return ReadInt(BOW_POUCH_SIZE);
        }

        public int ReadShieldPouch()
        {
            return ReadInt(SHIELD_POUCH_SIZE);
        }

        // WriteData
        public void WriteRupees(int value)
        {
            WriteInt(RUPEE_ADDRESS, value);
        }

        public void WriteHearts(int value)
        {
            WriteInt(HEART_ADDRESS, value * 4);
            WriteInt(MAX_HEART_ADDRESS, value * 4);
        }

        public void WriteStamina(int value)
        {
            WriteFloat(STAMINA_ADDRESS, value);
        }

        public void WriteSword(int slot, Item item)
        {
            WriteString(SWORD_ADDRESS + (slot * 0x40), item.Id);
        }

        public void WriteBow(int slot, Item item)
        {
            WriteString(BOW_ADDRESS + (slot * 0x40), item.Id);
        }

        public void WriteShield(int slot, Item item)
        {
            WriteString(SHIELD_ADDRESS + (slot * 0x40), item.Id);
        }

        public void WriteArmor(int slot, Item item)
        {
            WriteString(ARMOR_ADDRESS + (slot * 0x40), item.Id);
        }

        public void WriteSwordPouch(int value)
        {
            WriteInt(SWORD_POUCH_SIZE, value);
        }

        public void WriteBowPouch(int value)
        {
            WriteInt(BOW_POUCH_SIZE, value);
        }

        public void WriteShieldPouch(int value)
        {
            WriteInt(SHIELD_POUCH_SIZE, value);
        }
    }
}
