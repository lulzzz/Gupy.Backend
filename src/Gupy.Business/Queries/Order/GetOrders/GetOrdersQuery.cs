using System.Collections.Generic;
using Gupy.Core.Dtos;
using Gupy.Domain;
using MediatR;

namespace Gupy.Business.Queries.Order.GetOrders
{
    public class GetOrdersQuery : IRequest<List<OrderDto>>
    {
        public int? TelegramUserId { get; set; }
        public OrderStatus? OrderStatus { get; set; }
    }
}