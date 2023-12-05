using AutoMapper;
using DTO;
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
        IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetProducts(string? Desc, int? minPrice, int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            IEnumerable<Product> products = await _productService.GetProducts(Desc, minPrice, maxPrice, categoryIds);
            IEnumerable<ProductDTO> productDTOs = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return productDTOs;
        }
    }
}
