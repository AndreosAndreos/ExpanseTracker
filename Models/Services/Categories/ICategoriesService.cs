using ExpanseTracker.Models.Categories;

namespace ExpanseTracker.Models.Services.Categories
{
    public interface ICategoriesService
    {
        Task Create(CategoryCreateVM model);
        Task Delete(int id);
        Task Edit(CategoryEditVM model);
        Task<T?> GetAsync<T>(int id) where T : class;
        Task<List<CategoryReadOnlyVM>> GetAllCategoriesAsync();
        bool CategoryExists(int id);
        Task<bool> CheckIfCategoryExists(string name);
        Task<bool> CheckIfCategoryExistsForEdit(CategoryEditVM categoryEditVM);
    }
}