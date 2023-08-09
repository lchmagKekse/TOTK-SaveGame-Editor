using TOTK_SaveGame_Editor.Data;

namespace TOTK_SaveGame_Editor.Items
{
    public class Bow : Item
    {
        public Bow(string id, int durability, uint modifier)
        {
            Id = id;
            Durability = durability;

            Name = Id;
            Modifier = "None";

            if (GameData.Bows.ContainsKey(Id))
            {
                Name = GameData.Bows[Id];
            }

            if (GameData.Modifiers.ContainsKey(modifier))
            {
                Modifier = GameData.Modifiers[modifier];
            }
        }

        public int Durability { get; set; }
        public string Modifier { get; set; }
    }
}
