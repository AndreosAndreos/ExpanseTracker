using AutoMapper;
using ExpanseTracker.Data;
using ExpanseTracker.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace ExpanseTracker.Models.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoriesService(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<CategoryReadOnlyVM>> GetAllCategoriesAsync()
        {
            var data = await _context.Categories.ToListAsync();
            var viewData = _mapper.Map<List<CategoryReadOnlyVM>>(data);
            return viewData;
        }

        public async Task<T?> Get<T>(int id) where T : class
        {
            var data = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return null;
            }

            var dataView = _mapper.Map<T>(data);
            return dataView;
        }
        public async Task Delete(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
            if (category != null)
            {
                _context.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Edit(CategoryEditVM model)
        {
            var category = _mapper.Map<Category>(model);
            _context.Update(category);
            await _context.SaveChangesAsync();
        }
        public async Task Create(CategoryEditVM model)
        {
            var category = _mapper.Map<Category>(model);
            _context.Add(category);
            await _context.SaveChangesAsync();
        }
        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }

        private async Task<bool> CheckIfCategoryExists(string name)     // asynchronus method for checking if the entered value is already indatabase
        {
            var lowercase = name.ToLower();
            return await _context.Categories.AnyAsync(q => q.Name.ToLower().Equals(name));
            //return _context.Categories.Any(q => q.Name.Equals(categoryCreate.Name,StringComparison.InvariantCultureIgnoreCase));
        }

        private async Task<bool> CheckIfCategoryExistsForEdit(CategoryEditVM categoryEditVM)        // checks if the entered Name in edit is not already in the database with diferent ID
        {
            var lowercase = categoryEditVM.Name.ToLower();
            return await _context.Categories.AnyAsync(q => q.Name.ToLower().Equals(categoryEditVM.Name) && q.Id != categoryEditVM.Id);
        }
    }
}