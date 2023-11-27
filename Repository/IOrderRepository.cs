using DTO;
using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(OrderDto orderDto, OrderItemDto orderItemDto);
    }
}