using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyStoreContext _myStoreContext;

        public OrderRepository(MyStoreContext myStoreContext)
        {
            _myStoreContext = myStoreContext;
        }

        public async Task<Order> AddOrder(OrderDto orderDto, OrderItemDto orderItemDto)
        {
            //await _myStoreContext.Orders.AddAsync(orderDto);
            //foreach (var item in orderItemDto)
            //{
            //    await _myStoreContext.OrderItems.AddAsync(item);
            //}
            //await _myStoreContext.SaveChangesAsync();
            //return order;
            return null;
        }
    }
}
