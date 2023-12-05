using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<int> AddOrder(Order order);
    }
}