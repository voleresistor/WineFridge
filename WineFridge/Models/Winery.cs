using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineFridge.Models
{
    public class Winery
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Winery() { }

        public Winery(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}
