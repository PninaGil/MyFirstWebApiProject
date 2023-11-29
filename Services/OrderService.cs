using DTO;
using Entities;
using Microsoft.Extensions.Logging;
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
        IProductRepository _productRepository;
        ILogger<OrderService> _logger { get; }

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<int> AddOrder(OrderDTO orderDTO)
        {
        
            int sum = await _productRepository.GetProductsPriceAsync(orderDTO.OrderItems);

            if (sum != orderDTO.OrderSum)
                _logger.LogInformation($"UserId: {orderDTO.UserId} tried to stole!!");

            orderDTO.OrderSum = sum;

            return await _orderRepository.AddOrder(orderDTO);
        }
    }
}
