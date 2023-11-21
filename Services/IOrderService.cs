using Entities;

namespace Services
{
    public interface IOrderService
    {
        Task<Order> AddOrder(int userId, IEnumerable<Product> products);
    }
}