using System.ComponentModel.DataAnnotations.Schema;

namespace ExpanseTracker.Data
{
    public class Budget : BaseEntity
    {
        public decimal Amount { get; set; }
        public int Month { get; set; }

        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
