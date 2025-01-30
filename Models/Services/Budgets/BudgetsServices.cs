using AutoMapper;
using ExpanseTracker.Models.Budgets;
using Microsoft.EntityFrameworkCore;

namespace ExpanseTracker.Models.Services.Budget
{
    public class BudgetsServices(ApplicationDbContext _context, IMapper _mapper, IHttpContextAccessor _contextAccessor, UserManager<AppUser> _userManager) : IBudgetsServices
    {
        public async Task<List<BudgetReadOnlyVM>> GetAllBudgetsAnyc()
        {
            var data = await _context.Budgets
                .Include(e => e.User)
                .ToListAsync();
            var viewData = _mapper.Map<List<BudgetReadOnlyVM>>(data);
            return viewData;
        }

        public async Task<List<BudgetReadOnlyVM>> GetBudgetByIdAsync()
        {
            var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext?.User);

            var data = await _context.Budgets.
                Include(q => q.User).
                Where(q => q.UserId == user.Id).
                ToListAsync();
            var viewData = _mapper.Map<List<BudgetReadOnlyVM>>(data);
            return viewData;
        }

        public async Task<T?> GetAsync<T>(int id) where T : class
        {
            var data = await _context.Budgets
                .Include(e => e.User)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
            {
                return null;
            }

            var dataView = _mapper.Map<T>(data);
            return dataView;
        }
        public async Task Delete(int id)
        {
            var budgetDelete = await _context.Budgets.FirstOrDefaultAsync(x => x.Id == id);
            if (budgetDelete != null)
            {
                _context.Remove(budgetDelete);
                _context.SaveChanges();
            }
        }

        public async Task Create(BudgetCreateVM model)
        {
            var budget = new Budget
            {
                Amount = model.Amount,
                Month = model.Month,

                User = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == model.UserId)
            };
            _context.Add(budget);
            await _context.SaveChangesAsync();
        }


        public bool BudgetExists(int id)
        {
            return _context.Budgets.Any(e => e.Id == id);
        }
        public IEnumerable<AppUser> GetUsers()
        {
            return _userManager.Users.ToList();
        }
    }
}
