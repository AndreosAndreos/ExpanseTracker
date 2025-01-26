namespace ExpanseTracker.Models.Expenses
{
    public class ExpenseCreateVM : BaseExpenseVM
    {
        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, 1000000, ErrorMessage = "Amount must be between 0.01 and 1,000,000.")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        //[DateInPastOrToday(ErrorMessage = "Date cannot be in the future.")]
        public DateOnly Date { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Name must be between 4 and 100 characters long.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Name can only contain letters, numbers, and spaces.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
