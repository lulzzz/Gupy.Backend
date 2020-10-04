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
                .ForMember(p => p.Photo,
                    cfg => cfg.MapFrom(p => p.Photo.FileName));
            CreateMap<ProductDto, Product>()
                .ForMember(p => p.Photo,
                    cfg => cfg.Ignore());
        }
    }
}