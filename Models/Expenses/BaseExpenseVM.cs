namespace ExpanseTracker.Models.Expenses
{
    public abstract class BaseExpenseVM
    {
        [Required]
        public int Id { get; set; }
    }
}
