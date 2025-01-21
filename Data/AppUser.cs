using Microsoft.AspNetCore.Identity;

namespace ExpanseTracker.Data
{
    public class AppUser : IdentityUser         // inheritance so it has all the fields as in database
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }

        //public ICollection<Expense> Expenses { get; set; }
        //public ICollection<Category> Categories { get; set; }
    }
}
