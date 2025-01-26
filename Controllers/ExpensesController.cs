using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpanseTracker.Data;
using ExpanseTracker.Models.Services.Expenses;
using ExpanseTracker.Models.Expenses;
using ExpanseTracker.Models.Categories;

namespace ExpanseTracker.Controllers
{
    [Authorize(Roles = $"{Roles.Admin},{Roles.Manager},{Roles.User}")]
    public class ExpensesController(IExpensesService _expenseService) : Controller
    {
        private readonly ApplicationDbContext _context;
                                                                                // expense service injected so context not needed and ctor also not nedded
        //public ExpensesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: Expenses
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Expenses.Include(e => e.Category).Include(e => e.User);
            //return View(await applicationDbContext.ToListAsync());

            // Under this line: thas how you get all expanses: 

            if (User.IsInRole(Roles.Admin))
            {
                var viewData = await _expenseService.GetAllExpensesAnyc();
                return View(viewData);
            }
            else if (User.IsInRole(Roles.User))
            {
                var data = await _expenseService.GetExpenseByIdAsync();
                return View(data);
            }
            else
            {
                return View();
            }
        }

        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var expense = await _context.Expenses
            //    .Include(e => e.Category)
            //    .Include(e => e.User)
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var expense = await _expenseService.GetAsync<ExpenseReadOnlyVM>(id.Value);
            
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpenseCreateVM expenseCreate)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(expense);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                await _expenseService.Create(expenseCreate);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", expenseCreate.CategoryId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", expenseCreate.UserId);
            return View(expenseCreate);
        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _expenseService.GetAsync<ExpenseEditVM>(id.Value);

            if (expense == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", expense.CategoryId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", expense.UserId);
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ExpenseEditVM expense)
        {
            if (id != expense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(expense);
                    //await _context.SaveChangesAsync();
                    await _expenseService.Edit(expense);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_expenseService.ExpenseExists(expense.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", expense.CategoryId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", expense.UserId);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var expense = await _context.Expenses
            //    .Include(e => e.Category)
            //    .Include(e => e.User)
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var expense = await _expenseService.GetAsync<ExpenseReadOnlyVM>(id.Value);

            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var expense = await _context.Expenses.FindAsync(id);
            //if (expense != null)
            //{
            //    _context.Expenses.Remove(expense);
            //}

            await _expenseService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
