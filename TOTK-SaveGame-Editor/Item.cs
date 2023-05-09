using System.Xml.Linq;

namespace TOTK_SaveGame_Editor
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Item(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public Item(string id)
        {
            Id = id;
            Name = id;
        }
    }
}
