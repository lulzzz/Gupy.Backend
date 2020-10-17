using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Commands.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<OrderDto>
    {
        public OrderDto OrderDto { get; set; }
    }
}