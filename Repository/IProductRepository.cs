using DTO;
using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> GetProducts(string? Desc, int? minPrice, int? maxPrice, int?[] categoryIds);
        Task<int> GetProductsPriceAsync(IEnumerable<OrderItemDTO> orderItems);
    }
}