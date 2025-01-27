using System.ComponentModel.DataAnnotations;

namespace ExpanseTracker.Data
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public ICollection<Expense> Expenses { get; set; } // Relacja do wydatków
    }
}
