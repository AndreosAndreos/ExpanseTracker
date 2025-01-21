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
using ExpanseTracker.Models.Services.Categories;


namespace ExpanseTracker.Controllers
{
    [Authorize(Roles = $"{Roles.Admin},{Roles.Manager}")]
    public class CategoriesController(ICategoriesService _categoriesService) : Controller
    {
        //private readonly ICategoriesService _categoriesService = categoriesService;

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            // Without auto mapping:
            //var viewData = data.Select(q => new IndexVM
            //{
            //    Id = q.Id,
            //    Name = q.Name,
            //    Description = q.Description
            //});

            // with automapping:
            //var data = await _context.Categories.ToListAsync();
            //var viewData = _mapper.Map<List<CategoryReadOnlyVM>>(data);

            // using services:
            var viewData = await _categoriesService.GetAllCategoriesAsync();

            return View(viewData);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
            
            var category = await _categoriesService.GetAsync<CategoryReadOnlyVM>(id.Value);
            
            if (category == null)
            {
                return NotFound();
            }

            // automapping
            //var viewData = _mapper.Map<CategoryReadOnlyVM>(category);

            // manual mapping
            //var data = new CategoryReadOnlyVM
            //{
            //    Id = category.Id,
            //    Name = category.Name,
            //    Description = category.Description
            //};

            return View(category);
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

            //if(await CheckIfCategoryExists(categoryCreate.Name))
            //{
            //    ModelState.AddModelError(nameof(categoryCreate.Name),"This category already exists in database");
            //}

            if(await _categoriesService.CheckIfCategoryExists(categoryCreate.Name))
            {
                ModelState.AddModelError(nameof(categoryCreate.Name), "This category already exists in database");
            }

            if (ModelState.IsValid)     // if validation from obove gives an error it will already be FALSE
            {
                await _categoriesService.Create(categoryCreate);
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

            var category = await _categoriesService.GetAsync<CategoryEditVM>(id.Value);

            if (category == null)
            {
                return NotFound();
            }

            //var viewData = _mapper.Map<CategoryEditVM>(category);
            return View(category);
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

            //if (await CheckIfCategoryExistsForEdit(categoryEditVM))
            //{
            //    ModelState.AddModelError(nameof(categoryEditVM.Name), "This category already exists in database");
            //}
            if (await _categoriesService.CheckIfCategoryExistsForEdit(categoryEditVM))
            {
                ModelState.AddModelError(nameof(categoryEditVM.Name), "This category already exists in database");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //var category = _mapper.Map<Category>(categoryEditVM);
                    //_context.Update(category);
                    //await _context.SaveChangesAsync();
                    await _categoriesService.Edit(categoryEditVM);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_categoriesService.CategoryExists(categoryEditVM.Id))
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

            //var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
            var category = await _categoriesService.GetAsync<CategoryReadOnlyVM>(id.Value);

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
            //var category = await _context.Categories.FindAsync(id);

            //if (category != null)
            //{
            //    _context.Categories.Remove(category);
            //}

            //await _context.SaveChangesAsync();
            await _categoriesService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
