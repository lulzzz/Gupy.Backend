using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Queries.Order.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public int OrderId { get; set; }
    }
}