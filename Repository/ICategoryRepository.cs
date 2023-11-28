using DTO;
using Entities;

namespace Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
    }
}