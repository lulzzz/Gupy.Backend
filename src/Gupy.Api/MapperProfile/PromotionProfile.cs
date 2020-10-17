using AutoMapper;
using Gupy.Api.Models.Product;
using Gupy.Api.Models.Promotion;
using Gupy.Core.Dtos;

namespace Gupy.Api.MapperProfile
{
    public class PromotionProfile : Profile
    {
        public PromotionProfile()
        {
            CreateMap<CreatePromotionModel, PromotionDto>();
            CreateMap<UpdatePromotionModel, PromotionDto>();
        }
    }
}