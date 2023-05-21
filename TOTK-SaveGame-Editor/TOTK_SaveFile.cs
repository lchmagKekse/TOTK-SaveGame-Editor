using System.Collections.Generic;
using System.IO;
using TOTK_SaveGame_Editor.Offsets;
using TOTK_SaveGame_Editor.Data;
using System.Linq;

namespace TOTK_SaveGame_Editor
{
    public class TOTK_SaveFile : SaveFile
    {
        #region Offsets

        private int RUPEE_ADDRESS;              // 0x04 | int32 | Pattern: D7 21 79 A7       
        private int HEART_ADDRESS;              // 0x04 | int32 | Pattern: A1 1D E0 FB      
        private int MAX_HEART_ADDRESS;          // 0x04 | int32 | Pattern: 80 55 AB 31     
        private int STAMINA_ADDRESS;            // 0x04 | float | Pattern: 74 2C 21 F9

        private int SWORD_ADDRESS;
        private int BOW_ADDRESS;
        private int SHIELD_ADDRESS;
        private int ARMOR_ADDRESS;

        private int SWORD_DURABILITY;
        private int BOW_DURABILITY;
        private int SHIELD_DURABILITY;

        public int SWORD_MODIFIER;
        public int BOW_MODIFIER;
        public int SHIELD_MODIFIER;

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

        #endregion

        public int Rupees;
        public int Hearts;
        public int Stamina;

        public List<Sword> Swords;
        public List<Bow> Bows;
        public List<Shield> Shields;
        public List<Armor> Armor;

        public int Arrows;

        public int PouchSizeSwords;
        public int PouchSizeBows;
        public int PouchSizeShields;

        private int _SwordCount;
        private int _BowCount;
        private int _ShieldCount;
        private int _ArmorCount;

        public TOTK_SaveFile(string path)
        {
            if (!File.Exists(path)) return;

            _Path = path;
            _Data = File.ReadAllBytes(_Path);
            IsLoaded = true;

            CreateBackup();
            LoadOffsets();
            
            Rupees = ReadRupees();
            Hearts = ReadHearts();
            Stamina = ReadStamina();

            Arrows = ReadArrows();

            PouchSizeSwords = ReadSwordPouch();
            PouchSizeBows = ReadBowPouch();
            PouchSizeShields = ReadShieldPouch();

            Swords = ReadSwords();
            Bows = ReadBows();
            Shields = ReadShields();
            Armor = ReadArmor();

            _SwordCount = Swords.Count;
            _BowCount = Bows.Count;
            _ShieldCount = Shields.Count;
            _ArmorCount = Armor.Count;
        }

        private void LoadOffsets()
        {
            RUPEE_ADDRESS = FindBytePatternOffset(Offsets_Pattern.RUPEE_PATTERN);
            MAX_HEART_ADDRESS = FindBytePatternOffset(Offsets_Pattern.MAX_HEART_PATTERN);
            HEART_ADDRESS = FindBytePatternOffset(Offsets_Pattern.HEART_PATTERN);
            STAMINA_ADDRESS = FindBytePatternOffset(Offsets_Pattern.STAMINA_PATTERN);

            LOOKOUTLANDING_MAP = FindBytePatternOffset(Offsets_Pattern.LOOKOUTLANDING_MAP);
            GERUDOCANYON_MAP = FindBytePatternOffset(Offsets_Pattern.GERUDOCANYON_MAP);
            POPLAFOOTHILLS_MAP = FindBytePatternOffset(Offsets_Pattern.POPLAFOOTHILLS_MAP);
            MOUNTLANAYRU_MAP = FindBytePatternOffset(Offsets_Pattern.MOUNTLANAYRU_MAP);
            UPLANDZORANA_MAP = FindBytePatternOffset(Offsets_Pattern.UPLANDZORANA_MAP);
            ULRIMOUNTAIN_MAP = FindBytePatternOffset(Offsets_Pattern.ULRIMOUNTAIN_MAP);
            ELDINCANYON_MAP = FindBytePatternOffset(Offsets_Pattern.ELDINCANYON_MAP);
            THYPHLORUINS_MAP = FindBytePatternOffset(Offsets_Pattern.THYPHLORUINS_MAP);
            GERUDOHIGHLANDS_MAP = FindBytePatternOffset(Offsets_Pattern.GERUDOHIGHLANDS_MAP);
            HYRULEFIELD_MAP = FindBytePatternOffset(Offsets_Pattern.HYRULEFIELD_MAP);
            RABELLAWETLANDS_MAP = FindBytePatternOffset(Offsets_Pattern.RABELLAWETLANDS_MAP);
            PIKIDASTONEGROVE_MAP = FindBytePatternOffset(Offsets_Pattern.PIKIDASTONEGROVE_MAP);
            ROSPROPASS_MAP = FindBytePatternOffset(Offsets_Pattern.ROSPROPASS_MAP);
            LINDORSBROW_MAP = FindBytePatternOffset(Offsets_Pattern.LINDORSBROW_MAP);
            SAHASRASLOPE_MAP = FindBytePatternOffset(Offsets_Pattern.SAHASRASLOPE_MAP);

            LOOKOUTLANDING_TOWER_ACTIVE = FindBytePatternOffset(Offsets_Pattern.LOOKOUTLANDING_TOWER_ACTIVE);
            GERUDOCANYON_TOWER_ACTIVE = FindBytePatternOffset(Offsets_Pattern.GERUDOCANYON_TOWER_ACTIVE);
            POPLAFOOTHILLS_TOWER_ACTIVE = FindBytePatternOffset(Offsets_Pattern.POPLAFOOTHILLS_TOWER_ACTIVE);
            MOUNTLANAYRU_TOWER_ACTIVE = FindBytePatternOffset(Offsets_Pattern.MOUNTLANAYRU_TOWER_ACTIVE);
            UPLANDZORANA_TOWER_ACTIVE = FindBytePatternOffset(Offsets_Pattern.UPLANDZORANA_TOWER_ACTIVE);
            ULRIMOUNTAIN_TOWER_ACTIVE = FindBytePatternOffset(Offsets_Pattern.ULRIMOUNTAIN_TOWER_ACTIVE);
            ELDINCANYON_TOWER_ACTIVE = FindBytePatternOffset(Offsets_Pattern.ELDINCANYON_TOWER_ACTIVE);
            THYPHLORUINS_TOWER_ACTIVE = FindBytePatternOffset(Offsets_Pattern.THYPHLORUINS_TOWER_ACTIVE);
            GERUDOHIGHLANDS_TOWER_ACTIVE = FindBytePatternOffset(Offsets_Pattern.GERUDOHIGHLANDS_TOWER_ACTIVE);
            HYRULEFIELD_TOWER_ACTIVE = FindBytePatternOffset(Offsets_Pattern.HYRULEFIELD_TOWER_ACTIVE);
            RABELLAWETLANDS_TOWER_ACTIVE = FindBytePatternOffset(Offsets_Pattern.RABELLAWETLANDS_TOWER_ACTIVE);
            PIKIDASTONEGROVE_TOWER_ACTIVE = FindBytePatternOffset(Offsets_Pattern.PIKIDASTONEGROVE_TOWER_ACTIVE);
            ROSPROPASS_TOWER_ACTIVE = FindBytePatternOffset(Offsets_Pattern.ROSPROPASS_TOWER_ACTIVE);
            LINDORSBROW_TOWER_ACTIVE = FindBytePatternOffset(Offsets_Pattern.LINDORSBROW_TOWER_ACTIVE);
            SAHASRASLOPE_TOWER_ACTIVE = FindBytePatternOffset(Offsets_Pattern.SAHASRASLOPE_TOWER_ACTIVE);

            LOOKOUTLANDING_TOWER_PIN = FindBytePatternOffset(Offsets_Pattern.LOOKOUTLANDING_TOWER_PIN);
            GERUDOCANYON_TOWER_PIN = FindBytePatternOffset(Offsets_Pattern.GERUDOCANYON_TOWER_PIN);
            POPLAFOOTHILLS_TOWER_PIN = FindBytePatternOffset(Offsets_Pattern.POPLAFOOTHILLS_TOWER_PIN);
            MOUNTLANAYRU_TOWER_PIN = FindBytePatternOffset(Offsets_Pattern.MOUNTLANAYRU_TOWER_PIN);
            UPLANDZORANA_TOWER_PIN = FindBytePatternOffset(Offsets_Pattern.UPLANDZORANA_TOWER_PIN);
            ULRIMOUNTAIN_TOWER_PIN = FindBytePatternOffset(Offsets_Pattern.ULRIMOUNTAIN_TOWER_PIN);
            ELDINCANYON_TOWER_PIN = FindBytePatternOffset(Offsets_Pattern.ELDINCANYON_TOWER_PIN);
            THYPHLORUINS_TOWER_PIN = FindBytePatternOffset(Offsets_Pattern.THYPHLORUINS_TOWER_PIN);
            GERUDOHIGHLANDS_TOWER_PIN = FindBytePatternOffset(Offsets_Pattern.GERUDOHIGHLANDS_TOWER_PIN);
            HYRULEFIELD_TOWER_PIN = FindBytePatternOffset(Offsets_Pattern.HYRULEFIELD_TOWER_PIN);
            RABELLAWETLANDS_TOWER_PIN = FindBytePatternOffset(Offsets_Pattern.RABELLAWETLANDS_TOWER_PIN);
            PIKIDASTONEGROVE_TOWER_PIN = FindBytePatternOffset(Offsets_Pattern.PIKIDASTONEGROVE_TOWER_PIN);
            ROSPROPASS_TOWER_PIN = FindBytePatternOffset(Offsets_Pattern.ROSPROPASS_TOWER_PIN);
            LINDORSBROW_TOWER_PIN = FindBytePatternOffset(Offsets_Pattern.LINDORSBROW_TOWER_PIN);
            SAHASRASLOPE_TOWER_PIN = FindBytePatternOffset(Offsets_Pattern.SAHASRASLOPE_TOWER_PIN);

            if (_Data.Length == Offsets_1_0_0.FILESIZE)
            {
                SWORD_ADDRESS = Offsets_1_0_0.SWORD_ADDRESS;
                BOW_ADDRESS = Offsets_1_0_0.BOW_ADDRESS;
                SHIELD_ADDRESS = Offsets_1_0_0.SHIELD_ADDRESS;
                ARMOR_ADDRESS = Offsets_1_0_0.ARMOR_ADDRESS;

                SWORD_DURABILITY = Offsets_1_0_0.SWORD_DURABILITY;
                BOW_DURABILITY = Offsets_1_0_0.BOW_DURABILITY;
                SHIELD_DURABILITY = Offsets_1_0_0.SHIELD_DURABILITY;

                SWORD_MODIFIER = Offsets_1_0_0.SWORD_MODIFIER;
                BOW_MODIFIER = Offsets_1_0_0.BOW_MODIFIER;
                SHIELD_MODIFIER = Offsets_1_0_0.SHIELD_MODIFIER;

                SWORD_POUCH_SIZE = Offsets_1_0_0.SWORD_POUCH_SIZE;
                BOW_POUCH_SIZE = Offsets_1_0_0.BOW_POUCH_SIZE;
                SHIELD_POUCH_SIZE = Offsets_1_0_0.SHIELD_POUCH_SIZE;

                ARROW_ADDRESS = Offsets_1_0_0.ARROW_ADDRESS;

                return;
            }

            if (_Data.Length == Offsets_1_1_0.FILESIZE)
            {
                SWORD_ADDRESS = Offsets_1_1_0.SWORD_ADDRESS;
                BOW_ADDRESS = Offsets_1_1_0.BOW_ADDRESS;
                SHIELD_ADDRESS = Offsets_1_1_0.SHIELD_ADDRESS;
                ARMOR_ADDRESS = Offsets_1_1_0.ARMOR_ADDRESS;

                SWORD_DURABILITY = Offsets_1_1_0.SWORD_DURABILITY;
                BOW_DURABILITY = Offsets_1_1_0.BOW_DURABILITY;
                SHIELD_DURABILITY = Offsets_1_1_0.SHIELD_DURABILITY;

                SWORD_MODIFIER = Offsets_1_1_0.SWORD_MODIFIER;
                BOW_MODIFIER = Offsets_1_1_0.BOW_MODIFIER;
                SHIELD_MODIFIER = Offsets_1_1_0.SHIELD_MODIFIER;

                SWORD_POUCH_SIZE = Offsets_1_1_0.SWORD_POUCH_SIZE;
                BOW_POUCH_SIZE = Offsets_1_1_0.BOW_POUCH_SIZE;
                SHIELD_POUCH_SIZE = Offsets_1_1_0.SHIELD_POUCH_SIZE;

                ARROW_ADDRESS = Offsets_1_1_0.ARROW_ADDRESS;

                return;
            }
        }

        public void PatchSaveFile()
        {
            WriteRupees(Rupees);
            WriteHearts(Hearts);
            WriteStamina(Stamina);

            WriteArrows(Arrows);

            WriteSwordPouch(PouchSizeSwords);
            WriteBowPouch(PouchSizeBows);
            WriteShieldPouch(PouchSizeShields);

            RemoveItems();

            WriteSwords(Swords);
            WriteBows(Bows);
            WriteShields(Shields);
            WriteArmor(Armor);

            WriteSaveFile();
        }

        private void RemoveItems()
        {
            for (int index = 0; index < _SwordCount; index++)
            {
                WriteString(SWORD_ADDRESS + (0x40 * index), "");
            }

            for (int index = 0; index < _BowCount; index++)
            {
                WriteString(BOW_ADDRESS + (0x40 * index), "");
            }

            for (int index = 0; index < _ShieldCount; index++)
            {
                WriteString(SHIELD_ADDRESS + (0x40 * index), "");
            }

            for (int index = 0; index < _ArmorCount; index++)
            {
                WriteString(ARMOR_ADDRESS + (0x40 * index), "");
            }
        }

        private List<Sword> ReadSwords()
        {
            var Swords = new List<Sword>();

            for (int index = 0; index <= PouchSizeSwords; index++)
            {
                var id = ReadSword(index);

                if (string.IsNullOrWhiteSpace(id))
                {
                    break;
                }
                
                var durability = ReadSwordDurability(index);

                var modifier = ReadSwordModifier(index);

                Swords.Add(new Sword(id, durability, modifier));
            }

            return Swords;
        }

        private List<Bow> ReadBows()
        {
            var Bows = new List<Bow>();

            for (int index = 0; index <= PouchSizeBows; index++)
            {
                var id = ReadBow(index);

                if (string.IsNullOrWhiteSpace(id))
                {
                    break;
                }

                var durability = ReadBowDurability(index);

                var modifier = ReadBowModifier(index);

                Bows.Add(new Bow(id, durability, modifier));
            }

            return Bows;
        }

        private List<Shield> ReadShields()
        {
            var Shields = new List<Shield>();

            for (int index = 0; index <= PouchSizeShields; index++)
            {
                var id = ReadShield(index);

                if (string.IsNullOrWhiteSpace(id))
                {
                    break;
                }

                var durability = ReadShieldDurability(index);

                var modifier = ReadShieldModifier(index);

                Shields.Add(new Shield(id, durability, modifier));
            }

            return Shields;
        }

        private List<Armor> ReadArmor()
        {
            var armor = new List<Armor>();

            int index = 0;

            while(true)
            {
                var id = ReadArmor(index);

                if (string.IsNullOrWhiteSpace(id))
                {
                    break;
                }

                armor.Add(new Armor(id));

                index++;
            }

            return armor;
        }

        public void WriteSwords(List<Sword> swords)
        {         
            int index = 0;

            foreach (var sword in swords)
            {
                WriteSword(index, sword.Id);
                WriteSwordDurability(index, sword.Durability);

                var modifierId = GameData.Modifiers.FirstOrDefault(modifier => modifier.Value == sword.Modifier).Key;

                WriteSwordModifier(index, modifierId);

                index++;
            }
        }

        public void WriteBows(List<Bow> bows)
        {
            int index = 0;

            foreach (var bow in bows)
            {
                WriteBow(index, bow.Id);
                WriteBowDurability(index, bow.Durability);

                var modifierId = GameData.Modifiers.FirstOrDefault(modifier => modifier.Value == bow.Modifier).Key;

                WriteBowModifier(index, modifierId);

                index++;
            }
        }

        public void WriteShields(List<Shield> shields)
        {
            int index = 0;

            foreach (var shield in shields)
            {
                WriteShield(index, shield.Id);
                WriteShieldDurability(index, shield.Durability);

                var modifierId = GameData.Modifiers.FirstOrDefault(modifier => modifier.Value == shield.Modifier).Key;

                WriteShieldModifier(index, modifierId);

                index++;
            }
        }

        public void WriteArmor(List<Armor> armor)
        {
            int index = 0;

            foreach (var item in armor)
            {
                WriteArmor(index, item.Id);
                index++;
            }
        }

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

        public uint ReadSwordModifier(int slot)
        {
            return ReadUInt32(SWORD_MODIFIER + (slot * 0x04));
        }

        public uint ReadBowModifier(int slot)
        {
            return ReadUInt32(BOW_MODIFIER + (slot * 0x04));
        }

        public uint ReadShieldModifier(int slot)
        {
            return ReadUInt32(SHIELD_MODIFIER + (slot * 0x04));
        }

        public int ReadSwordDurability(int slot)
        {
            return ReadInt(SWORD_DURABILITY +  (slot * 0x04));
        }

        public int ReadBowDurability(int slot)
        {
            return ReadInt(BOW_DURABILITY + (slot * 0x04));
        }

        public int ReadShieldDurability(int slot)
        {
            return ReadInt(SHIELD_DURABILITY + (slot * 0x04));
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

        public void WriteSword(int slot, string item)
        {
            WriteString(SWORD_ADDRESS + (slot * 0x40), item);
        }

        public void WriteBow(int slot, string item)
        {
            WriteString(BOW_ADDRESS + (slot * 0x40), item);
        }

        public void WriteShield(int slot, string item)
        {
            WriteString(SHIELD_ADDRESS + (slot * 0x40), item);
        }

        public void WriteArmor(int slot, string item)
        {
            WriteString(ARMOR_ADDRESS + (slot * 0x40), item);
        }

        public void WriteSwordDurability(int slot, int value)
        {
            WriteInt(SWORD_DURABILITY + (slot * 0x04), value);
        }

        public void WriteBowDurability(int slot, int value)
        {
            WriteInt(BOW_DURABILITY + (slot * 0x04), value);
        }

        public void WriteShieldDurability(int slot, int value)
        {
            WriteInt(SHIELD_DURABILITY + (slot * 0x04), value);
        }

        public void WriteSwordModifier(int slot, uint value)
        {
            WriteUInt32(SWORD_MODIFIER + (slot * 0x04), value);
        }
        public void WriteBowModifier(int slot, uint value)
        {
            WriteUInt32(BOW_MODIFIER + (slot * 0x04), value);
        }
        public void WriteShieldModifier(int slot, uint value)
        {
            WriteUInt32(SHIELD_MODIFIER + (slot * 0x04), value);
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
