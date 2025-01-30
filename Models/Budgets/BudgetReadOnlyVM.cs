namespace ExpanseTracker.Models.Budgets
{
    public class BudgetReadOnlyVM : BaseBudgetVM
    {
        public decimal Amount { get; set; }
        public int Month {  get; set; }
        public int MyProperty { get; set; }
        public string? UserId { get; set; }
    }
}
