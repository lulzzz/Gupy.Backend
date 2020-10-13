using Gupy.Core.Dtos;
using Gupy.Domain;
using MediatR;

namespace Gupy.Business.Commands.Order.ChangerOrderStatus
{
    public class ChangeOrderStatusCommand : IRequest<OrderDto>
    {
        public int OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}