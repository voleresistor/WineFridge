using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WineFridge.Models;

namespace WineFridge.ViewModels
{
    public class AddBottleViewModel
    {
        public int WineID { get; set; }
        public List<SelectListItem> Wines { get; set; }

        public AddBottleViewModel() { }

        public AddBottleViewModel(List<Wine> wineList)
        {
            List<SelectListItem> wines = new List<SelectListItem>();

            foreach (Wine w in wineList)
            {
                wines.Add(new SelectListItem
                {
                    Value = w.ID.ToString(),
                    Text = w.Name
                });
            }

            Wines = wines;
        }
    }
}
