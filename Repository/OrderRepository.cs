using AutoMapper;
using Entities;

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
        public async Task<int> AddOrder(Order order)
        {
            await _myStoreContext.Orders.AddAsync(order);
            await _myStoreContext.SaveChangesAsync();
            int orderId = order.OrderId;
            return orderId;
        }
    }
}
