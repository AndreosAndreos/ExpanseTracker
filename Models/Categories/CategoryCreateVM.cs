using System.ComponentModel.DataAnnotations;

namespace ExpanseTracker.Models.Categories
{
    public class CategoryCreateVM
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Name must be between 4 and 100 characters long.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Name can only contain letters, numbers, and spaces.")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Length(1, 100, ErrorMessage = "You have vialated the Description length requirement")]
        public string Description { get; set; } = string.Empty;
    }
}
