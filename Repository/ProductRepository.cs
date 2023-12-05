using AutoMapper;
using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyStoreContext _myStoreContext;
        IMapper _mapper;

        public ProductRepository(MyStoreContext myStoreContext, IMapper mapper)
        {
            _myStoreContext = myStoreContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Product>> GetProducts(string? Desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = _myStoreContext.Products.Where(product =>
            ((Desc == null ? (true) : (product.ProductName.Contains(Desc)))
            || (Desc == null ? (true) : (product.Description.Contains(Desc))))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId)))
            ).OrderBy(product => product.ProductName).Include(product => product.Category);


            IEnumerable<Product> products = await query.ToListAsync();
            return products;
        }

        public async Task<int> GetProductsPriceAsync(IEnumerable<OrderItem> orderItems)
        {
            int sum = 0;
            foreach (var item in orderItems)
            {
                var product = await _myStoreContext.Products.FindAsync(item.ProductId);
                if (product != null)
                    sum += product.Price * item.Quantity;
            }
            return sum;
        }

    }
}
