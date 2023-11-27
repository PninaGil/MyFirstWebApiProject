
using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService _orderService;
        IMapper _mapper;
        

        public OrderController(IOrderService orderService,IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<Order> Post([FromBody] Order order)//אפשר להכניס משהו מסוג dto
        {
            OrderDto orderDto = _mapper.Map<Order, OrderDto>(order);
            OrderItemDto  orderItemDto = _mapper.Map<OrderItem, OrderItemDto>((OrderItem)order.OrderItems);
            return await _orderService.AddOrder(orderDto, orderItemDto);
        }
    }
}
