using ExpanseTracker.Models.Categories;

namespace ExpanseTracker.Models.Services
{
    public interface ICategoriesService
    {
        Task Create(CategoryEditVM model);
        Task Delete(int id);
        Task Edit(CategoryEditVM model);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<CategoryReadOnlyVM>> GetAllCategoriesAsync();
    }
}