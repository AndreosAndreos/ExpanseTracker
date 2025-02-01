namespace ExpanseTracker.Models.Services.Budget
{
    public interface IBudgetsServices
    {
        bool BudgetExists(int id);
        Task Create(BudgetCreateVM model);
        Task Delete(int id);
        Task Edit(BudgetEditVM model);
        Task<List<BudgetReadOnlyVM>> GetAllBudgetsAsync();
        Task<T?> GetAsync<T>(int id) where T : class;
        Task<List<BudgetReadOnlyVM>> GetBudgetByIdAsync();
        IEnumerable<AppUser> GetUsers();
    }
}