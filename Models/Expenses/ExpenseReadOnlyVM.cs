namespace ExpanseTracker.Models.Expenses
{
    public class ExpenseReadOnlyVM : BaseExpenseVM
    {
        public decimal Amount { get; set; }
        public DateOnly Date { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public AppUser User { get; set; }
        public string UserId { get; set; }
    }
}
