using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WineFridge.Models;

namespace WineFridge.ViewModels
{
    public class WineViewModel
    {
        public int WineID { get; set; }
        public Winery Winery { get; set; }
        public WineType Type { get; set; }
        public bool InStock { get; set; }

        [Required(ErrorMessage = "Please name your new wine.")]
        [Display(Name = "Wine Name")]
        public string Name { get; set; }

        [Display(Name = "Wine Description")]
        public string Description { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Display(Name = "Winery")]
        public int WineryID { get; set; }

        [Display(Name = "Wine Type")]
        public int TypeID { get; set; }

        [Display(Name = "Rating")]
        public int Rating { get; set; }
        public string RatingTxt { get; set; }

        [Display(Name = "Number of bottles")]
        public int Count { get; set; }

        public RackLocation Location { get; set; }

        public List<SelectListItem> Wineries { get; set; }
        public List<SelectListItem> Types { get; set; }

        public List<SelectListItem> Ratings { get; set; }

        public WineViewModel() { }

        public WineViewModel(List<Winery> wineries, List<WineType> types)
        {
            Wineries = new List<SelectListItem>();
            Types = new List<SelectListItem>();
            Ratings = new List<SelectListItem>();

            foreach (Winery w in wineries)
            {
                Wineries.Add(new SelectListItem
                {
                    Value = w.ID.ToString(),
                    Text = w.Name
                });
            }

            foreach (WineType t in types)
            {
                Types.Add(new SelectListItem
                {
                    Value = t.ID.ToString(),
                    Text = t.Name
                });
            }

            Ratings = Enum.GetValues(typeof(WineRatings)).Cast<WineRatings>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();

            Ratings.Reverse();
        }
    }
}
