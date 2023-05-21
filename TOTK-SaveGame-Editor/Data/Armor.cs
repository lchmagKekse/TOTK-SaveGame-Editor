namespace TOTK_SaveGame_Editor.Data
{
    public class Armor : Item
    {
        public Armor(string id)
        {
            Id = id;
            Name = id;

            if (GameData.Armor.ContainsKey(id))
            {
                Name = GameData.Armor[id];
            }
        }
    }
}
