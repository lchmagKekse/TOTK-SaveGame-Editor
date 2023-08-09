namespace TOTK_SaveGame_Editor.Data
{
    public static class Byte_Patterns
    {
        //General
        public static byte[] RUPEE_PATTERN                  = new byte[] { 0xD7, 0x21, 0x79, 0xA7 };
        public static byte[] MAX_HEART_PATTERN              = new byte[] { 0xA1, 0x1D, 0xE0, 0xFB };
        public static byte[] HEART_PATTERN                  = new byte[] { 0x80, 0x55, 0xAB, 0x31 };
        public static byte[] STAMINA_PATTERN                = new byte[] { 0x74, 0x2C, 0x21, 0xF9 };
        public static byte[] ARROW_PATTERN                  = new byte[] { 0x94, 0x7D, 0xB2, 0x53 };

        //Items
        public static byte[] SWORD_PATTERN                  = new byte[] { 0xBE, 0xD0, 0xEF, 0x65 };
        public static byte[] BOW_PATTERN                    = new byte[] { 0x0B, 0x4A, 0x1C, 0x79 };
        public static byte[] SHIELD_PATTERN                 = new byte[] { 0xF4, 0x90, 0x31, 0x27 };
        public static byte[] ARMOR_PATTERN                  = new byte[] { 0x49, 0x85, 0x4E, 0x75 };

        public static byte[] SWORD_DURABILITY_PATTERN       = new byte[] { 0x62, 0xD0, 0x12, 0x8B };
        public static byte[] BOW_DURABILITY_PATTERN         = new byte[] { 0x00, 0x92, 0x58, 0x60 };
        public static byte[] SHIELD_DURABILITY_PATTERN      = new byte[] { 0x19, 0x6D, 0x41, 0xC3 };

        public static byte[] SWORD_MODIFIER_PATTERN         = new byte[] { 0x88, 0x62, 0x84, 0xDD };
        public static byte[] BOW_MODIFIER_PATTERN           = new byte[] { 0xD5, 0xEE, 0x9A, 0xD5 };
        public static byte[] SHIELD_MODIFIER_PATTERN        = new byte[] { 0x0C, 0x41, 0x4B, 0x46 };

        public static byte[] SWORD_POUCH_SIZE_PATTERN       = new byte[] { 0xBA, 0xF6, 0xA3, 0xD7 };
        public static byte[] BOW_POUCH_SIZE_PATTERN         = new byte[] { 0xC2, 0x85, 0x17, 0xC6 };
        public static byte[] SHIELD_POUCH_SIZE_PATTERN      = new byte[] { 0x7D, 0x1E, 0x27, 0x05 };

        //Map
        public static byte[] LOOKOUTLANDING_MAP             = new byte[] { 0xCF, 0x2A, 0x4A, 0x03 };
        public static byte[] GERUDOCANYON_MAP               = new byte[] { 0x81, 0x4D, 0x40, 0x46 };
        public static byte[] POPLAFOOTHILLS_MAP             = new byte[] { 0x6D, 0x3A, 0x76, 0x14 };
        public static byte[] MOUNTLANAYRU_MAP               = new byte[] { 0x36, 0x88, 0x25, 0xD4 };
        public static byte[] UPLANDZORANA_MAP               = new byte[] { 0xAC, 0x73, 0x3E, 0xF4 };
        public static byte[] ULRIMOUNTAIN_MAP               = new byte[] { 0xC2, 0x3C, 0x15, 0x0D };
        public static byte[] ELDINCANYON_MAP                = new byte[] { 0x56, 0xE9, 0x45, 0xCA };
        public static byte[] THYPHLORUINS_MAP               = new byte[] { 0x2F, 0x3E, 0x39, 0x81 };
        public static byte[] GERUDOHIGHLANDS_MAP            = new byte[] { 0xAB, 0x33, 0xB1, 0xD1 };
        public static byte[] HYRULEFIELD_MAP                = new byte[] { 0xE8, 0x08, 0xA8, 0xDA };
        public static byte[] RABELLAWETLANDS_MAP            = new byte[] { 0x2D, 0xD3, 0xCF, 0x0A };
        public static byte[] PIKIDASTONEGROVE_MAP           = new byte[] { 0x8B, 0x1B, 0x79, 0x41 };
        public static byte[] ROSPROPASS_MAP                 = new byte[] { 0xD5, 0x47, 0x65, 0x43 };
        public static byte[] LINDORSBROW_MAP                = new byte[] { 0x50, 0x88, 0x6B, 0x1B };
        public static byte[] SAHASRASLOPE_MAP               = new byte[] { 0x40, 0x7E, 0xC7, 0x1D };

        //Skyview Tower Active
        public static byte[] LOOKOUTLANDING_TOWER_ACTIVE    = new byte[] { 0x53, 0x62, 0xFB, 0xB8 };
        public static byte[] GERUDOCANYON_TOWER_ACTIVE      = new byte[] { 0x54, 0x33, 0xAB, 0x0A };
        public static byte[] POPLAFOOTHILLS_TOWER_ACTIVE    = new byte[] { 0x6E, 0x21, 0xFB, 0x71 };
        public static byte[] MOUNTLANAYRU_TOWER_ACTIVE      = new byte[] { 0x4B, 0x5A, 0x64, 0xDC };
        public static byte[] UPLANDZORANA_TOWER_ACTIVE      = new byte[] { 0x21, 0x53, 0xEF, 0xB0 };
        public static byte[] ULRIMOUNTAIN_TOWER_ACTIVE      = new byte[] { 0x27, 0x22, 0xA5, 0x8D };
        public static byte[] ELDINCANYON_TOWER_ACTIVE       = new byte[] { 0x04, 0x53, 0x36, 0x1F };
        public static byte[] THYPHLORUINS_TOWER_ACTIVE      = new byte[] { 0xB7, 0xDD, 0xB4, 0xFC };
        public static byte[] GERUDOHIGHLANDS_TOWER_ACTIVE   = new byte[] { 0x49, 0x8F, 0xE6, 0x9E };
        public static byte[] HYRULEFIELD_TOWER_ACTIVE       = new byte[] { 0x88, 0x10, 0x93, 0xE8 };
        public static byte[] RABELLAWETLANDS_TOWER_ACTIVE   = new byte[] { 0x24, 0x56, 0x29, 0xB2 };
        public static byte[] PIKIDASTONEGROVE_TOWER_ACTIVE  = new byte[] { 0x37, 0x28, 0x4B, 0x1F };
        public static byte[] ROSPROPASS_TOWER_ACTIVE        = new byte[] { 0x44, 0xD8, 0xC6, 0xF6 };
        public static byte[] LINDORSBROW_TOWER_ACTIVE       = new byte[] { 0xE5, 0x6B, 0x23, 0xD0 };
        public static byte[] SAHASRASLOPE_TOWER_ACTIVE      = new byte[] { 0x80, 0xF0, 0x62, 0x84 };

        //Skyview Tower Pin
        public static byte[] LOOKOUTLANDING_TOWER_PIN       = new byte[] { 0x7A, 0x21, 0x07, 0x3C };
        public static byte[] GERUDOCANYON_TOWER_PIN         = new byte[] { 0x86, 0x86, 0x41, 0xE0 };
        public static byte[] POPLAFOOTHILLS_TOWER_PIN       = new byte[] { 0x3E, 0x3C, 0x25, 0xDB };
        public static byte[] MOUNTLANAYRU_TOWER_PIN         = new byte[] { 0x8B, 0xA5, 0xAE, 0xA7 };
        public static byte[] UPLANDZORANA_TOWER_PIN         = new byte[] { 0x23, 0xCE, 0x04, 0x93 };
        public static byte[] ULRIMOUNTAIN_TOWER_PIN         = new byte[] { 0xF6, 0x58, 0x94, 0xBC };
        public static byte[] ELDINCANYON_TOWER_PIN          = new byte[] { 0x2E, 0x27, 0xB1, 0xC1 };
        public static byte[] THYPHLORUINS_TOWER_PIN         = new byte[] { 0x3F, 0xB4, 0xAB, 0x8F };
        public static byte[] GERUDOHIGHLANDS_TOWER_PIN      = new byte[] { 0x13, 0x17, 0xB0, 0x89 };
        public static byte[] HYRULEFIELD_TOWER_PIN          = new byte[] { 0x50, 0x2B, 0xEE, 0x5E };
        public static byte[] RABELLAWETLANDS_TOWER_PIN      = new byte[] { 0x14, 0x41, 0xEC, 0x97 };
        public static byte[] PIKIDASTONEGROVE_TOWER_PIN     = new byte[] { 0xB4, 0xA9, 0xE7, 0x6E };
        public static byte[] ROSPROPASS_TOWER_PIN           = new byte[] { 0x10, 0x5C, 0x41, 0xF4 };
        public static byte[] LINDORSBROW_TOWER_PIN          = new byte[] { 0xBE, 0xC3, 0x38, 0xEC };
        public static byte[] SAHASRASLOPE_TOWER_PIN         = new byte[] { 0xC5, 0x4B, 0xBC, 0x6B };
    }
}
