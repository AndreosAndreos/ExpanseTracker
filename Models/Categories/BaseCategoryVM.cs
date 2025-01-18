using System.ComponentModel.DataAnnotations;

namespace ExpanseTracker.Models.Categories
{
    public abstract class BaseCategoryVM
    {
        [Required]
        public int Id { get; set; }

    }
}
