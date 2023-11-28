using DTO;
using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<int> AddOrder(OrderDTO orderDTO);
    }
}