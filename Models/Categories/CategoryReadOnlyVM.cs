using System.ComponentModel.DataAnnotations;

namespace ExpanseTracker.Models.Categories
{
    public class CategoryReadOnlyVM : BaseCategoryVM
    {
        //  Changing the table column name in the views
        //[Display(Name ="Name")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
