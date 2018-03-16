using System.ComponentModel.DataAnnotations;

namespace WineFridge.ViewModels
{
    public class WineTypeViewModel
    {
        public int TypeID { get; set; }

        [Required]
        [Display(Name = "Wine Type")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
