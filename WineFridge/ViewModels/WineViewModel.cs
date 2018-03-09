using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineFridge.ViewModels
{
    public class WineViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public KeyValuePair<string, int> Location { get; set; }
    }
}
