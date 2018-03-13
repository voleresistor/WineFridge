using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineFridge.Models;

namespace WineFridge.ViewModels
{
    public class WinesFromThisWineryViewModel
    {
        public Winery Winery { get; set; }
        public List<Wine> Wines { get; set; }

        public WinesFromThisWineryViewModel() { }

        public WinesFromThisWineryViewModel(List<Wine> wines, Winery winery)
        {
            Wines = wines;
            Winery = winery;
        }
    }
}
