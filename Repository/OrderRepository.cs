using DTO;
using Entities;
using AutoMapper;
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
        IMapper _mapper;

        public OrderRepository(MyStoreContext myStoreContext, IMapper mapper)
        {
            _myStoreContext = myStoreContext;
            _mapper = mapper;
        }

        public async Task<int> AddOrder(OrderDTO orderDTO)
        {
            Order order = _mapper.Map<OrderDTO,Order>(orderDTO);
            await _myStoreContext.Orders.AddAsync(order);
            await _myStoreContext.SaveChangesAsync();
            int orderId = order.OrderId;
            return orderId;
        }
    }
}
