using AutoMapper;
using Gupy.Api.Models.Product;
using Gupy.Core.Dtos;

namespace Gupy.Api.MapperProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductModel, ProductDto>()
                .ForMember(p => p.Id,
                    cfg => cfg.Ignore())
                .ForMember(p => p.Photo,
                    cfg => cfg.Ignore());


            CreateMap<UpdateProductModel, ProductDto>()
                .ForMember(p => p.Photo,
                    cfg => cfg.Ignore());
        }
    }
}