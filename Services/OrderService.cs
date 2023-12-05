using Entities;
using Microsoft.Extensions.Logging;
using Repository;

namespace Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        IProductRepository _productRepository;
        ILogger<OrderService> _logger { get; }

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<int> AddOrder(Order order)
        {

            int sum = await _productRepository.GetProductsPriceAsync(order.OrderItems);

            if (sum != order.OrderSum)
                _logger.LogError($"UserId: {order.UserId} tried to stole!!");

            order.OrderSum = sum;

            return await _orderRepository.AddOrder(order);
        }
    }
}
