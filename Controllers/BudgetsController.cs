namespace ExpanseTracker.Controllers
{
    [Authorize(Roles = $"{Roles.Admin},{Roles.Manager},{Roles.User}")]
    public class BudgetsController(IBudgetsServices _budgetsServices, UserManager<AppUser> _userManager) : Controller
    {
        private readonly ApplicationDbContext _context;

        // GET: Budgets
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(Roles.Admin))
            {
                var viewData = await _budgetsServices.GetAllBudgetsAsync();
                return View(viewData);
            }
            else if (User.IsInRole(Roles.User))
            {
                var data = await _budgetsServices.GetBudgetByIdAsync();
                return View(data);
            }
            else
            {
                return View();
            }
        }

        // GET: Budgets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budget = await _budgetsServices.GetAsync<BudgetReadOnlyVM>(id.Value);

            if (budget == null)
            {
                return NotFound();
            }

            return View(budget);
        }

        // GET: Budgets/Create
        public IActionResult Create()
        {
            if (User.IsInRole(Roles.Admin))
            {
                ViewBag.UserId = new SelectList(_budgetsServices.GetUsers(), "Id", "UserName");
            }
            else
            {
                var currentUserId = _userManager.GetUserId(User);
                ViewBag.CurrentUserId = currentUserId;
            }
            return View();
        }

        // POST: Budgets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BudgetCreateVM budget)
        {
            if (!User.IsInRole(Roles.Admin))
            {
                budget.UserId = _userManager.GetUserId(User);
            }
            if (User.IsInRole(Roles.Admin))
            {
                ViewBag.UserId = new SelectList(_budgetsServices.GetUsers(), "Id", "UserName", budget.UserId);
            }

            if (ModelState.IsValid)
            {
                await _budgetsServices.Create(budget);
                return RedirectToAction(nameof(Index));
            }
            return View(budget);
        }

        // GET: Budgets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budget = await _budgetsServices.GetAsync<BudgetEditVM>(id.Value);
            if (budget == null)
            {
                return NotFound();
            }

            if (!User.IsInRole(Roles.Admin))
            {
                budget.UserId = _userManager.GetUserId(User);
                ViewBag.CurrentUserId = budget.UserId;
            }
            if (User.IsInRole(Roles.Admin))
            {
                ViewBag.UserId = new SelectList(_budgetsServices.GetUsers(), "Id", "UserName", budget.UserId);
            }

            return View(budget);
        }

        // POST: Budgets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BudgetEditVM budget)
        {
            if (id != budget.Id)
            {
                return NotFound();
            }

            if (!User.IsInRole(Roles.Admin))
            {
                budget.UserId = _userManager.GetUserId(User);
            }
            if (User.IsInRole(Roles.Admin))
            {
                ViewBag.UserId = new SelectList(_budgetsServices.GetUsers(), "Id", "UserName", budget.UserId);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _budgetsServices.Edit(budget);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_budgetsServices.BudgetExists(budget.Id))
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
            
            return View(budget);
        }

        // GET: Budgets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budget = await _budgetsServices.GetAsync<BudgetReadOnlyVM>(id.Value);

            if (budget == null)
            {
                return NotFound();
            }

            return View(budget);
        }

        // POST: Budgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _budgetsServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
