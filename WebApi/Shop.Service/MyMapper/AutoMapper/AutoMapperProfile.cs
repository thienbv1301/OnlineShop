using AutoMapper;
using Shop.Data.Models;
using Shop.Service.Dto;

namespace Shop.Service.MyMapper.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Size, m => m.MapFrom(e => e.Size.Name))
                .ForMember(d => d.Color, m => m.MapFrom(e => e.Color.Name))
                .ForMember(d => d.Images, m => m.MapFrom(e => e.Images));           
            CreateMap<ProductDto, Product>();
        }
    }
}
