using System.Collections.Generic;
using WineFridge.Models;

namespace WineFridge.ViewModels
{
    public class WineListViewModel
    {
        public Winery Winery { get; set; }
        public WineType WineType { get; set; }
        public List<Wine> Wines { get; set; }

        public WineListViewModel() { }

        public WineListViewModel(List<Wine> wines, Winery winery)
        {
            Wines = wines;
            Winery = winery;
        }

        public WineListViewModel(List<Wine> wines, WineType wineType)
        {
            Wines = wines;
            WineType = wineType;
        }
    }
}
