using AutoMapper;
using Gupy.Core.Dtos;
using Gupy.Domain;

namespace Gupy.Core.MapperProfiles
{
    public class PromotionProfile : Profile
    {
        public PromotionProfile()
        {
            CreateMap<PromotionDto, Promotion>()
                .ForMember(p => p.Id, cfg => cfg.Ignore());
            CreateMap<Promotion, PromotionDto>();
        }
    }
}