using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MyFirstWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts(string? Desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await _productService.GetProducts(Desc, minPrice, maxPrice, categoryIds);
        }
    }
}
