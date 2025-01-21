using System.ComponentModel.DataAnnotations.Schema;

namespace ExpanseTracker.Data
{
    public class Expense : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}

