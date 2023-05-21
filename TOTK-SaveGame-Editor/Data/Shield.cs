namespace TOTK_SaveGame_Editor.Data
{
    public class Shield : Item
    {
        public Shield(string id, int durability, uint modifier)
        {
            Id = id;
            Durability = durability;

            Name = Id;
            Modifier = "None";

            if (GameData.Shields.ContainsKey(Id))
            {
                Name = GameData.Shields[Id];
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
