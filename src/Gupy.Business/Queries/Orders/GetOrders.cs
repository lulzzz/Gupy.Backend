using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Business.Specifications.Orders;
using Gupy.Core.Common;
using Gupy.Core.Dtos;
using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;
using MediatR;

namespace Gupy.Business.Queries.Orders
{
    public class GetOrdersQuery : IRequest<List<OrderDto>>
    {
        public int? TelegramUserId { get; set; }
        public OrderStatus? OrderStatus { get; set; }
    }

    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var specifications = new List<Specification<Order>>();
            if (request.TelegramUserId != null)
            {
                specifications.Add(new OrderOfUserSpecification(request.TelegramUserId.Value));
            }

            if (request.OrderStatus != null)
            {
                specifications.Add(new OrderStatusSpecification(request.OrderStatus.Value));
            }

            var orders = await _orderRepository.ListAsync(specifications: specifications.ToArray());
            var result = _mapper.Map<List<OrderDto>>(orders);
            return result;
        }
    }
}