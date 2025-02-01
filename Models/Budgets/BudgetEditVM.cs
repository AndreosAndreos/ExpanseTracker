namespace ExpanseTracker.Models.Budgets
{
    public class BudgetEditVM : BaseBudgetVM
    {
        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, 1000000, ErrorMessage = "Amount must be between 0.01 and 1,000,000.")]
        public decimal Amount { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Month number must be between 1 and 12")]
        public int Month { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public string? UserId { get; set; }
    }
}
