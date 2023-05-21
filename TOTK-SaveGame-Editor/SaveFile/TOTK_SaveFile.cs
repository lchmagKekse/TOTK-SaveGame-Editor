using System.Collections.Generic;
using System.IO;
using System.Linq;
using TOTK_SaveGame_Editor.Data;
using TOTK_SaveGame_Editor.Items;

namespace TOTK_SaveGame_Editor.SaveFile
{
    public class TOTK_SaveFile : SaveFile
    {
        #region Offsets

        private int RUPEE_ADDRESS;           
        private int HEART_ADDRESS;          
        private int MAX_HEART_ADDRESS;     
        private int STAMINA_ADDRESS;
        
        private int ARROW_ADDRESS;

        private int SWORD_ADDRESS;
        private int BOW_ADDRESS;
        private int SHIELD_ADDRESS;
        private int ARMOR_ADDRESS;

        private int SWORD_DURABILITY;
        private int BOW_DURABILITY;
        private int SHIELD_DURABILITY;

        private int SWORD_MODIFIER;
        private int BOW_MODIFIER;
        private int SHIELD_MODIFIER;

        private int SWORD_POUCH_SIZE;
        private int BOW_POUCH_SIZE;
        private int SHIELD_POUCH_SIZE;

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
            RUPEE_ADDRESS                           = FindBytePatternOffset(Byte_Patterns.RUPEE_PATTERN);
            MAX_HEART_ADDRESS                       = FindBytePatternOffset(Byte_Patterns.MAX_HEART_PATTERN);
            HEART_ADDRESS                           = FindBytePatternOffset(Byte_Patterns.HEART_PATTERN);
            STAMINA_ADDRESS                         = FindBytePatternOffset(Byte_Patterns.STAMINA_PATTERN);

            ARROW_ADDRESS                           = ReadInt(FindBytePatternOffset(Byte_Patterns.ARROW_PATTERN)) + 0x04;

            SWORD_ADDRESS                           = ReadInt(FindBytePatternOffset(Byte_Patterns.SWORD_PATTERN)) + 0x04;
            BOW_ADDRESS                             = ReadInt(FindBytePatternOffset(Byte_Patterns.BOW_PATTERN)) + 0x04;
            SHIELD_ADDRESS                          = ReadInt(FindBytePatternOffset(Byte_Patterns.SHIELD_PATTERN)) + 0x04;
            ARMOR_ADDRESS                           = ReadInt(FindBytePatternOffset(Byte_Patterns.ARMOR_PATTERN)) + 0x04;

            SWORD_DURABILITY                        = ReadInt(FindBytePatternOffset(Byte_Patterns.SWORD_DURABILITY_PATTERN)) + 0x04;
            BOW_DURABILITY                          = ReadInt(FindBytePatternOffset(Byte_Patterns.BOW_DURABILITY_PATTERN)) + 0x04;
            SHIELD_DURABILITY                       = ReadInt(FindBytePatternOffset(Byte_Patterns.SHIELD_DURABILITY_PATTERN)) + 0x04;

            SWORD_MODIFIER                          = ReadInt(FindBytePatternOffset(Byte_Patterns.SWORD_MODIFIER_PATTERN)) + 0x04;
            BOW_MODIFIER                            = ReadInt(FindBytePatternOffset(Byte_Patterns.BOW_MODIFIER_PATTERN)) + 0x04;
            SHIELD_MODIFIER                         = ReadInt(FindBytePatternOffset(Byte_Patterns.SHIELD_MODIFIER_PATTERN)) + 0x04;

            SWORD_POUCH_SIZE                        = ReadInt(FindBytePatternOffset(Byte_Patterns.SWORD_POUCH_SIZE_PATTERN)) + 0x04;
            BOW_POUCH_SIZE                          = ReadInt(FindBytePatternOffset(Byte_Patterns.BOW_POUCH_SIZE_PATTERN)) + 0x04;
            SHIELD_POUCH_SIZE                       = ReadInt(FindBytePatternOffset(Byte_Patterns.SHIELD_POUCH_SIZE_PATTERN)) + 0x04;

            LOOKOUTLANDING_MAP                      = FindBytePatternOffset(Byte_Patterns.LOOKOUTLANDING_MAP);
            GERUDOCANYON_MAP                        = FindBytePatternOffset(Byte_Patterns.GERUDOCANYON_MAP);
            POPLAFOOTHILLS_MAP                      = FindBytePatternOffset(Byte_Patterns.POPLAFOOTHILLS_MAP);
            MOUNTLANAYRU_MAP                        = FindBytePatternOffset(Byte_Patterns.MOUNTLANAYRU_MAP);
            UPLANDZORANA_MAP                        = FindBytePatternOffset(Byte_Patterns.UPLANDZORANA_MAP);
            ULRIMOUNTAIN_MAP                        = FindBytePatternOffset(Byte_Patterns.ULRIMOUNTAIN_MAP);
            ELDINCANYON_MAP                         = FindBytePatternOffset(Byte_Patterns.ELDINCANYON_MAP);
            THYPHLORUINS_MAP                        = FindBytePatternOffset(Byte_Patterns.THYPHLORUINS_MAP);
            GERUDOHIGHLANDS_MAP                     = FindBytePatternOffset(Byte_Patterns.GERUDOHIGHLANDS_MAP);
            HYRULEFIELD_MAP                         = FindBytePatternOffset(Byte_Patterns.HYRULEFIELD_MAP);
            RABELLAWETLANDS_MAP                     = FindBytePatternOffset(Byte_Patterns.RABELLAWETLANDS_MAP);
            PIKIDASTONEGROVE_MAP                    = FindBytePatternOffset(Byte_Patterns.PIKIDASTONEGROVE_MAP);
            ROSPROPASS_MAP                          = FindBytePatternOffset(Byte_Patterns.ROSPROPASS_MAP);
            LINDORSBROW_MAP                         = FindBytePatternOffset(Byte_Patterns.LINDORSBROW_MAP);
            SAHASRASLOPE_MAP                        = FindBytePatternOffset(Byte_Patterns.SAHASRASLOPE_MAP);

            LOOKOUTLANDING_TOWER_ACTIVE             = FindBytePatternOffset(Byte_Patterns.LOOKOUTLANDING_TOWER_ACTIVE);
            GERUDOCANYON_TOWER_ACTIVE               = FindBytePatternOffset(Byte_Patterns.GERUDOCANYON_TOWER_ACTIVE);
            POPLAFOOTHILLS_TOWER_ACTIVE             = FindBytePatternOffset(Byte_Patterns.POPLAFOOTHILLS_TOWER_ACTIVE);
            MOUNTLANAYRU_TOWER_ACTIVE               = FindBytePatternOffset(Byte_Patterns.MOUNTLANAYRU_TOWER_ACTIVE);
            UPLANDZORANA_TOWER_ACTIVE               = FindBytePatternOffset(Byte_Patterns.UPLANDZORANA_TOWER_ACTIVE);
            ULRIMOUNTAIN_TOWER_ACTIVE               = FindBytePatternOffset(Byte_Patterns.ULRIMOUNTAIN_TOWER_ACTIVE);
            ELDINCANYON_TOWER_ACTIVE                = FindBytePatternOffset(Byte_Patterns.ELDINCANYON_TOWER_ACTIVE);
            THYPHLORUINS_TOWER_ACTIVE               = FindBytePatternOffset(Byte_Patterns.THYPHLORUINS_TOWER_ACTIVE);
            GERUDOHIGHLANDS_TOWER_ACTIVE            = FindBytePatternOffset(Byte_Patterns.GERUDOHIGHLANDS_TOWER_ACTIVE);
            HYRULEFIELD_TOWER_ACTIVE                = FindBytePatternOffset(Byte_Patterns.HYRULEFIELD_TOWER_ACTIVE);
            RABELLAWETLANDS_TOWER_ACTIVE            = FindBytePatternOffset(Byte_Patterns.RABELLAWETLANDS_TOWER_ACTIVE);
            PIKIDASTONEGROVE_TOWER_ACTIVE           = FindBytePatternOffset(Byte_Patterns.PIKIDASTONEGROVE_TOWER_ACTIVE);
            ROSPROPASS_TOWER_ACTIVE                 = FindBytePatternOffset(Byte_Patterns.ROSPROPASS_TOWER_ACTIVE);
            LINDORSBROW_TOWER_ACTIVE                = FindBytePatternOffset(Byte_Patterns.LINDORSBROW_TOWER_ACTIVE);
            SAHASRASLOPE_TOWER_ACTIVE               = FindBytePatternOffset(Byte_Patterns.SAHASRASLOPE_TOWER_ACTIVE);

            LOOKOUTLANDING_TOWER_PIN                = FindBytePatternOffset(Byte_Patterns.LOOKOUTLANDING_TOWER_PIN);
            GERUDOCANYON_TOWER_PIN                  = FindBytePatternOffset(Byte_Patterns.GERUDOCANYON_TOWER_PIN);
            POPLAFOOTHILLS_TOWER_PIN                = FindBytePatternOffset(Byte_Patterns.POPLAFOOTHILLS_TOWER_PIN);
            MOUNTLANAYRU_TOWER_PIN                  = FindBytePatternOffset(Byte_Patterns.MOUNTLANAYRU_TOWER_PIN);
            UPLANDZORANA_TOWER_PIN                  = FindBytePatternOffset(Byte_Patterns.UPLANDZORANA_TOWER_PIN);
            ULRIMOUNTAIN_TOWER_PIN                  = FindBytePatternOffset(Byte_Patterns.ULRIMOUNTAIN_TOWER_PIN);
            ELDINCANYON_TOWER_PIN                   = FindBytePatternOffset(Byte_Patterns.ELDINCANYON_TOWER_PIN);
            THYPHLORUINS_TOWER_PIN                  = FindBytePatternOffset(Byte_Patterns.THYPHLORUINS_TOWER_PIN);
            GERUDOHIGHLANDS_TOWER_PIN               = FindBytePatternOffset(Byte_Patterns.GERUDOHIGHLANDS_TOWER_PIN);
            HYRULEFIELD_TOWER_PIN                   = FindBytePatternOffset(Byte_Patterns.HYRULEFIELD_TOWER_PIN);
            RABELLAWETLANDS_TOWER_PIN               = FindBytePatternOffset(Byte_Patterns.RABELLAWETLANDS_TOWER_PIN);
            PIKIDASTONEGROVE_TOWER_PIN              = FindBytePatternOffset(Byte_Patterns.PIKIDASTONEGROVE_TOWER_PIN);
            ROSPROPASS_TOWER_PIN                    = FindBytePatternOffset(Byte_Patterns.ROSPROPASS_TOWER_PIN);
            LINDORSBROW_TOWER_PIN                   = FindBytePatternOffset(Byte_Patterns.LINDORSBROW_TOWER_PIN);
            SAHASRASLOPE_TOWER_PIN                  = FindBytePatternOffset(Byte_Patterns.SAHASRASLOPE_TOWER_PIN);
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
