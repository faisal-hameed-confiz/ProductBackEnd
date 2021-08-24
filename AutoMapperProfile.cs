using AutoMapper;
using ProductBackEnd.Dtos.Product;
using ProductBackEnd.Models;

namespace ProductBackEnd
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, GetProductDto>();
            CreateMap<AddProductDto, Product>();
        }
    }
}