using System.ComponentModel.DataAnnotations;

namespace ExpanseTracker.Data
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public ICollection<Expense> Expenses { get; set; } // Relacja do wydatków
    }
}
