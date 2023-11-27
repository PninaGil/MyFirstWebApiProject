
using AutoMapper;
using DTO;
using Entities;


namespace MyFirstWebApiProject
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Product, ProductDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        }
    }
}
