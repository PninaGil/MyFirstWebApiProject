using AutoMapper;
using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyStoreContext _myStoreContext;
        IMapper _mapper;

        public CategoryRepository(MyStoreContext myStoreContext, IMapper mapper)
        {
            _myStoreContext = myStoreContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            IEnumerable<Category> category = await _myStoreContext.Categories.ToListAsync();
            IEnumerable<CategoryDTO> categoryDTO = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(category);
            return categoryDTO;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _myStoreContext.Categories.FindAsync(id);
        }
    }
}
