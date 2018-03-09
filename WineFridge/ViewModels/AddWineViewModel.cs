using System.ComponentModel.DataAnnotations;

namespace WineFridge.ViewModels
{
    public class AddWineViewModel
    {
        [Required(ErrorMessage = "Please name your new wine.")]
        [Display(Name = "Wine Name")]
        public string Name { get; set; }

        [Display(Name = "Wine Description")]
        public string Description { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }
    }
}
