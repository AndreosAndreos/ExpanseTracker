using AutoMapper;
using ExpanseTracker.Models.Categories;
using ExpanseTracker.Models.Expenses;
using Microsoft.EntityFrameworkCore;

namespace ExpanseTracker.Models.Services.Expenses
{
    public class ExpenseService(ApplicationDbContext _context, IMapper _mapper, IHttpContextAccessor _contextAccessor, UserManager<AppUser> _userManager) : IExpensesService
    {
        public async Task<List<ExpenseReadOnlyVM>> GetAllExpensesAnyc()
        {
            var data = await _context.Expenses.ToListAsync();
            var viewData = _mapper.Map<List<ExpenseReadOnlyVM>>(data);
            return viewData;
        }

        public async Task<List<ExpenseReadOnlyVM>> GetExpenseByIdAsync()
        {
            var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext?.User);

            var data = await _context.Expenses.
                Include(q => q.User).
                Include(q => q.Category). 
                Where(q => q.UserId == user.Id).
                ToListAsync();
            var viewData = _mapper.Map<List<ExpenseReadOnlyVM>>(data);
            return viewData;
        }

        public async Task<T?> GetAsync<T>(int id) where T : class
        {
            var data = await _context.Expenses.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return null;
            }

            var dataView = _mapper.Map<T>(data);
            return dataView;
        }

        public async Task Create(ExpenseCreateVM model)
        {
            var expense = _mapper.Map<Expense>(model);
            _context.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var expenseDelete = _context.Expenses.FirstOrDefaultAsync(x => x.Id == id);
            if(expenseDelete != null)
            {
                _context.Remove(expenseDelete);
                _context.SaveChanges();
            }
        }

        public async Task Edit(ExpenseEditVM model)
        {
            var expense = _mapper.Map<Expense>(model);
            _context.Update(expense);
            await _context.SaveChangesAsync();
        }

        public bool ExpenseExists(int id)
        {
            return _context.Expenses.Any(e => e.Id == id);
        }
    }
}
