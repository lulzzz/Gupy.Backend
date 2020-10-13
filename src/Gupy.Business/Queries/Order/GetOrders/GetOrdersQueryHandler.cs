using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Business.Specifications;
using Gupy.Core.Common;
using Gupy.Core.Dtos;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Queries.Order.GetOrders
{
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
            Specification<Domain.Order> specification = null;
            if (request.TelegramUserId != null)
            {
                specification = new OrderOfUserSpecification(request.TelegramUserId.Value);
            }

            if (request.OrderStatus != null)
            {
                var spec = new OrderStatusSpecification(request.OrderStatus.Value);
                specification = specification != null ? specification.And(spec) : spec;
            }

            var orders = await _orderRepository.ListAsync(specification);
            var result = _mapper.Map<List<OrderDto>>(orders);
            return result;
        }
    }
}