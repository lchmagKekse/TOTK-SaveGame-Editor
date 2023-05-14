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

        private int SWORD_POUCH_SIZE;
        private int BOW_POUCH_SIZE;
        private int SHIELD_POUCH_SIZE;

        private int ARROW_ADDRESS;

        public int LOOKOUTLANDING_MAP;
        public int GERUDOCANYON_MAP;
        public int POPLAFOOTHILLS_MAP;
        public int MOUNTLANAYRU_MAP;
        public int UPLANDZORANA_MAP;
        public int ULRIMOUNTAIN_MAP;
        public int ELDINCANYON_MAP;
        public int THYPHLORUINS_MAP;
        public int GERUDOHIGHLANDS_MAP;
        public int HYRULEFIELD_MAP;
        public int RABELLAWETLANDS_MAP;
        public int PIKIDASTONEGROVE_MAP;
        public int ROSPROPASS_MAP;
        public int LINDORSBROW_MAP;
        public int SAHASRASLOPE_MAP;

        public int LOOKOUTLANDING_TOWER_ACTIVE;
        public int GERUDOCANYON_TOWER_ACTIVE;
        public int POPLAFOOTHILLS_TOWER_ACTIVE;
        public int MOUNTLANAYRU_TOWER_ACTIVE;
        public int UPLANDZORANA_TOWER_ACTIVE;
        public int ULRIMOUNTAIN_TOWER_ACTIVE;
        public int ELDINCANYON_TOWER_ACTIVE;
        public int THYPHLORUINS_TOWER_ACTIVE;
        public int GERUDOHIGHLANDS_TOWER_ACTIVE;
        public int HYRULEFIELD_TOWER_ACTIVE;
        public int RABELLAWETLANDS_TOWER_ACTIVE;
        public int PIKIDASTONEGROVE_TOWER_ACTIVE;
        public int ROSPROPASS_TOWER_ACTIVE;
        public int LINDORSBROW_TOWER_ACTIVE;
        public int SAHASRASLOPE_TOWER_ACTIVE;

        public int LOOKOUTLANDING_TOWER_PIN;
        public int GERUDOCANYON_TOWER_PIN;
        public int POPLAFOOTHILLS_TOWER_PIN;
        public int MOUNTLANAYRU_TOWER_PIN;
        public int UPLANDZORANA_TOWER_PIN;
        public int ULRIMOUNTAIN_TOWER_PIN;
        public int ELDINCANYON_TOWER_PIN;
        public int THYPHLORUINS_TOWER_PIN;
        public int GERUDOHIGHLANDS_TOWER_PIN;
        public int HYRULEFIELD_TOWER_PIN;
        public int RABELLAWETLANDS_TOWER_PIN;
        public int PIKIDASTONEGROVE_TOWER_PIN;
        public int ROSPROPASS_TOWER_PIN;
        public int LINDORSBROW_TOWER_PIN;
        public int SAHASRASLOPE_TOWER_PIN;


        public SaveFile(string path)
        {
            if (!File.Exists(path)) return;

            _Path = path;
            _Data = File.ReadAllBytes(_Path);
            IsLoaded = true;

            CreateBackup();

            RUPEE_ADDRESS                       = FindBytePatternOffset(Offsets_Pattern.RUPEE_PATTERN);
            MAX_HEART_ADDRESS                   = FindBytePatternOffset(Offsets_Pattern.MAX_HEART_PATTERN);
            HEART_ADDRESS                       = FindBytePatternOffset(Offsets_Pattern.HEART_PATTERN);
            STAMINA_ADDRESS                     = FindBytePatternOffset(Offsets_Pattern.STAMINA_PATTERN);

            LOOKOUTLANDING_MAP                  = FindBytePatternOffset(Offsets_Pattern.LOOKOUTLANDING_MAP);
            GERUDOCANYON_MAP                    = FindBytePatternOffset(Offsets_Pattern.GERUDOCANYON_MAP);
            POPLAFOOTHILLS_MAP                  = FindBytePatternOffset(Offsets_Pattern.POPLAFOOTHILLS_MAP);
            MOUNTLANAYRU_MAP                    = FindBytePatternOffset(Offsets_Pattern.MOUNTLANAYRU_MAP);
            UPLANDZORANA_MAP                    = FindBytePatternOffset(Offsets_Pattern.UPLANDZORANA_MAP);
            ULRIMOUNTAIN_MAP                    = FindBytePatternOffset(Offsets_Pattern.ULRIMOUNTAIN_MAP);
            ELDINCANYON_MAP                     = FindBytePatternOffset(Offsets_Pattern.ELDINCANYON_MAP);
            THYPHLORUINS_MAP                    = FindBytePatternOffset(Offsets_Pattern.THYPHLORUINS_MAP);
            GERUDOHIGHLANDS_MAP                 = FindBytePatternOffset(Offsets_Pattern.GERUDOHIGHLANDS_MAP);
            HYRULEFIELD_MAP                     = FindBytePatternOffset(Offsets_Pattern.HYRULEFIELD_MAP);
            RABELLAWETLANDS_MAP                 = FindBytePatternOffset(Offsets_Pattern.RABELLAWETLANDS_MAP);
            PIKIDASTONEGROVE_MAP                = FindBytePatternOffset(Offsets_Pattern.PIKIDASTONEGROVE_MAP);
            ROSPROPASS_MAP                      = FindBytePatternOffset(Offsets_Pattern.ROSPROPASS_MAP);
            LINDORSBROW_MAP                     = FindBytePatternOffset(Offsets_Pattern.LINDORSBROW_MAP);
            SAHASRASLOPE_MAP                    = FindBytePatternOffset(Offsets_Pattern.SAHASRASLOPE_MAP);

            LOOKOUTLANDING_TOWER_ACTIVE         = FindBytePatternOffset(Offsets_Pattern.LOOKOUTLANDING_TOWER_ACTIVE);
            GERUDOCANYON_TOWER_ACTIVE           = FindBytePatternOffset(Offsets_Pattern.GERUDOCANYON_TOWER_ACTIVE);
            POPLAFOOTHILLS_TOWER_ACTIVE         = FindBytePatternOffset(Offsets_Pattern.POPLAFOOTHILLS_TOWER_ACTIVE);
            MOUNTLANAYRU_TOWER_ACTIVE           = FindBytePatternOffset(Offsets_Pattern.MOUNTLANAYRU_TOWER_ACTIVE);
            UPLANDZORANA_TOWER_ACTIVE           = FindBytePatternOffset(Offsets_Pattern.UPLANDZORANA_TOWER_ACTIVE);
            ULRIMOUNTAIN_TOWER_ACTIVE           = FindBytePatternOffset(Offsets_Pattern.ULRIMOUNTAIN_TOWER_ACTIVE);
            ELDINCANYON_TOWER_ACTIVE            = FindBytePatternOffset(Offsets_Pattern.ELDINCANYON_TOWER_ACTIVE);
            THYPHLORUINS_TOWER_ACTIVE           = FindBytePatternOffset(Offsets_Pattern.THYPHLORUINS_TOWER_ACTIVE);
            GERUDOHIGHLANDS_TOWER_ACTIVE        = FindBytePatternOffset(Offsets_Pattern.GERUDOHIGHLANDS_TOWER_ACTIVE);
            HYRULEFIELD_TOWER_ACTIVE            = FindBytePatternOffset(Offsets_Pattern.HYRULEFIELD_TOWER_ACTIVE);
            RABELLAWETLANDS_TOWER_ACTIVE        = FindBytePatternOffset(Offsets_Pattern.RABELLAWETLANDS_TOWER_ACTIVE);
            PIKIDASTONEGROVE_TOWER_ACTIVE       = FindBytePatternOffset(Offsets_Pattern.PIKIDASTONEGROVE_TOWER_ACTIVE);
            ROSPROPASS_TOWER_ACTIVE             = FindBytePatternOffset(Offsets_Pattern.ROSPROPASS_TOWER_ACTIVE);
            LINDORSBROW_TOWER_ACTIVE            = FindBytePatternOffset(Offsets_Pattern.LINDORSBROW_TOWER_ACTIVE);
            SAHASRASLOPE_TOWER_ACTIVE           = FindBytePatternOffset(Offsets_Pattern.SAHASRASLOPE_TOWER_ACTIVE);

            LOOKOUTLANDING_TOWER_PIN            = FindBytePatternOffset(Offsets_Pattern.LOOKOUTLANDING_TOWER_PIN);
            GERUDOCANYON_TOWER_PIN              = FindBytePatternOffset(Offsets_Pattern.GERUDOCANYON_TOWER_PIN);
            POPLAFOOTHILLS_TOWER_PIN            = FindBytePatternOffset(Offsets_Pattern.POPLAFOOTHILLS_TOWER_PIN);
            MOUNTLANAYRU_TOWER_PIN              = FindBytePatternOffset(Offsets_Pattern.MOUNTLANAYRU_TOWER_PIN);
            UPLANDZORANA_TOWER_PIN              = FindBytePatternOffset(Offsets_Pattern.UPLANDZORANA_TOWER_PIN);
            ULRIMOUNTAIN_TOWER_PIN              = FindBytePatternOffset(Offsets_Pattern.ULRIMOUNTAIN_TOWER_PIN);
            ELDINCANYON_TOWER_PIN               = FindBytePatternOffset(Offsets_Pattern.ELDINCANYON_TOWER_PIN);
            THYPHLORUINS_TOWER_PIN              = FindBytePatternOffset(Offsets_Pattern.THYPHLORUINS_TOWER_PIN);
            GERUDOHIGHLANDS_TOWER_PIN           = FindBytePatternOffset(Offsets_Pattern.GERUDOHIGHLANDS_TOWER_PIN);
            HYRULEFIELD_TOWER_PIN               = FindBytePatternOffset(Offsets_Pattern.HYRULEFIELD_TOWER_PIN);
            RABELLAWETLANDS_TOWER_PIN           = FindBytePatternOffset(Offsets_Pattern.RABELLAWETLANDS_TOWER_PIN);
            PIKIDASTONEGROVE_TOWER_PIN          = FindBytePatternOffset(Offsets_Pattern.PIKIDASTONEGROVE_TOWER_PIN);
            ROSPROPASS_TOWER_PIN                = FindBytePatternOffset(Offsets_Pattern.ROSPROPASS_TOWER_PIN);
            LINDORSBROW_TOWER_PIN               = FindBytePatternOffset(Offsets_Pattern.LINDORSBROW_TOWER_PIN);
            SAHASRASLOPE_TOWER_PIN              = FindBytePatternOffset(Offsets_Pattern.SAHASRASLOPE_TOWER_PIN);


            if (_Data.Length == Offsets_1_0_0.FILESIZE)
            {
                SWORD_ADDRESS       = Offsets_1_0_0.SWORD_ADDRESS;
                BOW_ADDRESS         = Offsets_1_0_0.BOW_ADDRESS;
                SHIELD_ADDRESS      = Offsets_1_0_0.SHIELD_ADDRESS;
                ARMOR_ADDRESS       = Offsets_1_0_0.ARMOR_ADDRESS;

                SWORD_POUCH_SIZE    = Offsets_1_0_0.SWORD_POUCH_SIZE;
                BOW_POUCH_SIZE      = Offsets_1_0_0.BOW_POUCH_SIZE;
                SHIELD_POUCH_SIZE   = Offsets_1_0_0.SHIELD_POUCH_SIZE;

                ARROW_ADDRESS       = Offsets_1_0_0.ARROW_ADDRESS;

                return;
            }

            if (_Data.Length == Offsets_1_1_0.FILESIZE)
            {
                SWORD_ADDRESS       = Offsets_1_1_0.SWORD_ADDRESS;
                BOW_ADDRESS         = Offsets_1_1_0.BOW_ADDRESS;
                SHIELD_ADDRESS      = Offsets_1_1_0.SHIELD_ADDRESS;
                ARMOR_ADDRESS       = Offsets_1_1_0.ARMOR_ADDRESS;

                SWORD_POUCH_SIZE    = Offsets_1_1_0.SWORD_POUCH_SIZE;
                BOW_POUCH_SIZE      = Offsets_1_1_0.BOW_POUCH_SIZE;
                SHIELD_POUCH_SIZE   = Offsets_1_1_0.SHIELD_POUCH_SIZE;

                ARROW_ADDRESS       = Offsets_1_1_0.ARROW_ADDRESS;

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

        public int ReadArrows()
        {
            return ReadInt(ARROW_ADDRESS);
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

        public void WriteArrows(int value)
        {
            WriteInt(ARROW_ADDRESS, value);
        }
    }
}
