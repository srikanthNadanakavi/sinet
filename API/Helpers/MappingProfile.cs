using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Entities.OrderAggregate;

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

             CreateMap<Core.Entities.Identity.Address, AddressDto>().ReverseMap();
             CreateMap<AddressDto,Core.Entities.OrderAggregate.Address>();
             CreateMap<CustomerBasketDto,CustomerBasket>();
             CreateMap<BasketItemDto,BasketItem>();
             CreateMap<Order, OrderToReturnDto>()
             .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
             .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));

             CreateMap<OrderItem,OrderItemDto>()
             .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
             .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
             .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
            
        }
        
    }
}