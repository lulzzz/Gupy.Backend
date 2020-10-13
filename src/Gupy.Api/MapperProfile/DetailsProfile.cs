using AutoMapper;
using Gupy.Api.Models.ShippingDetails;
using Gupy.Core.Dtos;

namespace Gupy.Api.MapperProfile
{
    public class DetailsProfile : Profile
    {
        public DetailsProfile()
        {
            CreateMap<CreateDetailsModel, ShippingDetailsDto>();
        }
    }
}