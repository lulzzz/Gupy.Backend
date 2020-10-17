using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Queries.Orders.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public int OrderId { get; set; }
    }
}