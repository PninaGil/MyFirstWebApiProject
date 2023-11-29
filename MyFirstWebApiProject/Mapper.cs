
using AutoMapper;
using DTO;
using Entities;


namespace MyFirstWebApiProject
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
        }
    }
}
