using DTO;
using Entities;

namespace Services
{
    public interface IOrderService
    {
        Task<int> AddOrder(OrderDTO orderDTO);
    }
}