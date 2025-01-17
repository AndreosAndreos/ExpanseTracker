using System.ComponentModel.DataAnnotations;

namespace ExpanseTracker.Models.Categories
{
    public class IndexVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
