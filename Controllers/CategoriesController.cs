using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpanseTracker.Data;
using ExpanseTracker.Models.Categories;
using AutoMapper;

namespace ExpanseTracker.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var data = await _context.Categories.ToListAsync();

            //var viewData = data.Select(q => new IndexVM
            //{
            //    Id = q.Id,
            //    Name = q.Name,
            //    Description = q.Description
            //});

            var viewData = _mapper.Map<List<CategoryReadOnlyVM>>(data);

            return View(viewData);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            // automapping
            var viewData = _mapper.Map<CategoryReadOnlyVM>(category);

            // manual mapping
            //var data = new CategoryReadOnlyVM
            //{
            //    Id = category.Id,
            //    Name = category.Name,
            //    Description = category.Description
            //};

            return View(viewData);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        //public async Task<IActionResult> Create([Bind("Id,Name,Description")] Category category)

        // when using mapping you can change the binding to the CreateViewModel binding you preapared for this action
        public async Task<IActionResult> Create(CategoryCreateVM categoryCreate)
        {

            // adding own validation and error, it will add an error to the ModelState

            //if(categoryCreate.Name.Contains("SomeName"))
            //{
            //    ModelState.AddModelError(nameof(categoryCreate.Name),"You cannot use this name! ");     // use nameof() so you're ready for the variable change
            //}

            if(await CheckIfCategoryExists(categoryCreate.Name))
            {
                ModelState.AddModelError(nameof(categoryCreate.Name),"This category already exists in database");
            }

            if (ModelState.IsValid)     // if validation from obove gives an error it will already be FALSE
            {
                var category = _mapper.Map<Category>(categoryCreate);
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryCreate);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            
            if (category == null)
            {
                return NotFound();
            }

            var viewData = _mapper.Map<CategoryEditVM>(category);
            return View(viewData);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryEditVM categoryEditVM)
        {
            if (id != categoryEditVM.Id)
            {
                return NotFound();
            }

            if (await CheckIfCategoryExistsForEdit(categoryEditVM))
            {
                ModelState.AddModelError(nameof(categoryEditVM.Name), "This category already exists in database");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var category = _mapper.Map<Category>(categoryEditVM);
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(categoryEditVM.Id))
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
            return View(categoryEditVM);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
