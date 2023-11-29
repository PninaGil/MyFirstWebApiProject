using AutoMapper;
using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<ProductDTO>> GetProducts(string? Desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = _myStoreContext.Products.Where(product =>
            (Desc == null ? (true) : (product.ProductName.Contains(Desc)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId)))
            ).OrderBy(product => product.ProductName);
            //.Skip((position-1)*skip)
            //.Take(skip);
            Console.WriteLine(query.ToQueryString());
            IEnumerable<Product> products = await query.ToListAsync();
            IEnumerable<ProductDTO> productDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return productDTO;
        }

        public async Task<int> GetProductsPriceAsync(IEnumerable<OrderItemDTO> orderItems)
        {
            int sum = 0;
            foreach (var item in orderItems)
            {
                var product = await _myStoreContext.Products.FindAsync(item.ProductId);
                if(product!=null)
                    sum += product.Price * item.Quantity;
            }
            return sum;
        }

    }
}
