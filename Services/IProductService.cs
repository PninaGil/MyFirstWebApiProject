using DTO;
using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts(string? Desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}