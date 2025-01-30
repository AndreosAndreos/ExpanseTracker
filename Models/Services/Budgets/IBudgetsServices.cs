using ExpanseTracker.Models.Budgets;

namespace ExpanseTracker.Models.Services.Budget
{
    public interface IBudgetsServices
    {
        bool BudgetExists(int id);
        Task Delete(int id);
        Task<List<BudgetReadOnlyVM>> GetAllBudgetsAnyc();
        Task<T?> GetAsync<T>(int id) where T : class;
        Task<List<BudgetReadOnlyVM>> GetBudgetByIdAsync();
        IEnumerable<AppUser> GetUsers();
    }
}