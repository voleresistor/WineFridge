using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Rack")]
        public string Rack { get; set; }

        [Display(Name = "Slot")]
        public string Slot { get; set; }

        [Required]
        [Display(Name = "Wine Rating (1-5)")]
        [Range(1, 5, ErrorMessage = "Please enter a rating between 1 and 5")]
        public int Rating { get; set; }

        [Display(Name = "Number of bottles")]
        public int Count { get; set; }

        public List<SelectListItem> Wineries { get; set; }
        public List<SelectListItem> Types { get; set; }

        public WineViewModel() { }

        public WineViewModel(List<Winery> wineries, List<WineType> types)
        {
            Wineries = new List<SelectListItem>();
            Types = new List<SelectListItem>();

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
        }
    }
}
