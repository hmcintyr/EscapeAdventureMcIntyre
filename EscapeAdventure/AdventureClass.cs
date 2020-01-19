using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeAdventure
{

    public class Dungeon
    {
        StringComparer comparer = StringComparer.OrdinalIgnoreCase;
        //var caseInsensitiveDictionary = new Dictionary<string, int>(comparer);
        public Dictionary<string, Room> Rooms { get; set; }
    }
    public class Room
    {
        public string Description { get; set; }
        public Dictionary<string, Item> Items { get; set; }
        public Dictionary<string, Door> Doors { get; set; }

    }

    public class Item
    {
        public string Description { get; set; }
        public string Name { get; set; }

    }

    public class Door
    {
        public string NextRoom { get; set; }
    }

    public class Adventurer
    {
        public Dictionary<string, Item> Items { get; set; }

        public Adventurer()
        {
            Items = new Dictionary<string, Item>();
        }
    }
}
