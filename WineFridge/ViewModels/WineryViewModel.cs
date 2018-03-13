using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WineFridge.Models;

namespace WineFridge.ViewModels
{
    public class WineryViewModel
    {
        public int WineryID { get; set; }
        public List<Wine> Wines { get; set; }

        [Required]
        [Display(Name = "Winery Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Winery Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [Phone]
        public string Phone { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Website")]
        public string Website { get; set; }

        [Display(Name = "Winery Notes")]
        public string Notes { get; set; }

        public WineryViewModel() { }

        public WineryViewModel(List<Wine> wines)
        {
            Wines = wines;
        }
    }
}
