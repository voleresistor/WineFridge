using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using WineFridge.Models;

namespace WineFridge.ViewModels
{
    public class AddBottleViewModel
    {
        public int WineID { get; set; }
        public List<SelectListItem> Wines { get; set; }
        public int RackID { get; set; }
        public List<SelectListItem> RackLocations { get; set; }

        public AddBottleViewModel() { }

        public AddBottleViewModel(List<Wine> wineList, List<RackLocation> rackLocations)
        {
            List<SelectListItem> Wines = new List<SelectListItem>();
            List<SelectListItem> RackLocations = new List<SelectListItem>();

            foreach (Wine w in wineList)
            {
                Wines.Add(new SelectListItem
                {
                    Value = w.ID.ToString(),
                    Text = w.Name
                });
            }

            RackLocations = Enum.GetValues(typeof(RackCode)).Cast<RackCode>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();
        }
    }
}
