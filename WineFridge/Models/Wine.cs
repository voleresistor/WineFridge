using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineFridge.Models
{
    public class Wine
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }

        /*
        public Winery Winery { get; set; }
        public int WineryID { get; set; }

        public WineType Type { get; set; }
        public int TypeID { get; set; }
        */

        public int Rating { get; set; }
        public bool InStock { get; set; }
        public int Count { get; set; }
        public string Location { get; set; }

        public Wine() { }

        /*
        public Wine(string name, int wineryId, int typeId, bool inStock, string location)
        {
            Name = name;
            WineryID = wineryId;
            TypeID = typeId;
            InStock = inStock;
            Location = location;
        }
        */

        public Wine(string name, bool inStock, string location)
        {
            Name = name;
            InStock = inStock;
            Location = location;
        }
    }
}
