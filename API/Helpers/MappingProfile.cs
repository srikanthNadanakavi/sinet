using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>()
            .ForMember(dest => dest.ProductBrand , src => src.MapFrom( s => s.ProductBrand.Name))
            .ForMember(dest => dest.ProductType , src => src.MapFrom( s => s.ProductType.Name))
            .ForMember(dest => dest.PictureUrl , src => src.MapFrom<ProductUrlResolver>());
        }
        
    }
}