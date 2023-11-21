using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public async Task<Order> AddOrder(int userId, IEnumerable<Product> products)
        {
            Order order = new Order();

            order.UserId = userId;
            order.OrderDate = DateTime.Today;

            int sum = 0;
            foreach (var p in products)
            {
                sum += p.Price;
            }
            order.OrderSum = sum;

            return await _orderRepository.AddOrder(order);
        }
    }
}
