using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts(string? Desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}