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

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<Order> Post([FromBody] int userId, [FromQuery] IEnumerable<Product> products)
        {
            return await _orderService.AddOrder(userId, products);
        }
    }
}
