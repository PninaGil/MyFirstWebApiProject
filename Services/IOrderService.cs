using DTO;
using Entities;

namespace Services
{
    public interface IOrderService
    {
        Task<Order> AddOrder(OrderDto orderDto, OrderItemDto orderItemDto);
    }
}