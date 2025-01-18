using System.ComponentModel.DataAnnotations;

namespace ExpanseTracker.Models.Categories
{
    public class CategoryEditVM : BaseCategoryVM
    {
        [Required]
        [Length(4, 100, ErrorMessage = "You have vialated the Name length requirement")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Length(4, 100, ErrorMessage = "You have vialated the Description length requirement")]
        public string Description { get; set; } = string.Empty;
    }
}
