namespace ExpanseTracker.Models.Expenses
{
    public class ExpenseReadOnlyVM : BaseExpenseVM
    {
        public decimal Amount { get; set; }
        public DateOnly Date { get; set; }
        public string Name { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
