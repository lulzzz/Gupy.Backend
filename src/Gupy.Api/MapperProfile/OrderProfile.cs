using AutoMapper;
using Gupy.Api.Models.Order;
using Gupy.Core.Dtos;

namespace Gupy.Api.MapperProfile
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderModel, OrderDto>();
            CreateMap<CreateOrderItemModel, OrderItemDto>();
        }
    }
}