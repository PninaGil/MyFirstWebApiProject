using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(string? Desc, int? minPrice, int? maxPrice, int?[] categoryIds);
        Task<int> GetProductsPriceAsync(IEnumerable<OrderItem> orderItems);
    }
}