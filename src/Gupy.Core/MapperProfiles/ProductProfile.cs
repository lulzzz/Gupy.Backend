using AutoMapper;
using Gupy.Core.Dtos;
using Gupy.Domain;

namespace Gupy.Core.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(p => p.PromotionMessage, cfg => cfg.MapFrom(p => p.Promotion.Message))
                .ForMember(p => p.PromotionPrice, cfg => cfg.MapFrom(p => p.Promotion.Price));

            CreateMap<ProductDto, Product>()
                .ForMember(p => p.Photo, cfg => cfg.Ignore());
        }
    }
}