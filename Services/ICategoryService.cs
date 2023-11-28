using DTO;
using Entities;

namespace Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
    }
}