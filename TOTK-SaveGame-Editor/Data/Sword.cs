namespace TOTK_SaveGame_Editor.Data
{
    public class Sword : Item
    {
        public Sword(string id, int durability, uint modifier)
        {
            Id = id;
            Durability = durability;

            Name = Id;
            Modifier = "None";

            if (GameData.Swords.ContainsKey(Id))
            {
                Name = GameData.Swords[Id];
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
