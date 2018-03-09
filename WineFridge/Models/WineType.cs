using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineFridge.Models
{
    public class WineType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public WineType() { }

        public WineType(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
