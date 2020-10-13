using AutoMapper;
using Gupy.Core.Dtos;
using Gupy.Domain;

namespace Gupy.Core.MapperProfiles
{
    public class ShippingDetailsProfile : Profile
    {
        public ShippingDetailsProfile()
        {
            CreateMap<ShippingDetails, ShippingDetailsDto>();
            CreateMap<ShippingDetailsDto, ShippingDetails>();
        }
    }
}