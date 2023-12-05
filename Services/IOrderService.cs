using Entities;

namespace Services
{
    public interface IOrderService
    {
        Task<int> AddOrder(Order order);
    }
}