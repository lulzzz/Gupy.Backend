using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Core.Dtos;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;
using MediatR;

namespace Gupy.Business.Commands.Orders
{
    public class ChangeOrderCommand : IRequest<OrderDto>
    {
        public int OrderId { get; set; }
        public DateTime? DateShipped { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }

    public class ChangeOrderCommandHandler : IRequestHandler<ChangeOrderCommand, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public ChangeOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(ChangeOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderWithItems(request.OrderId);
            if (order == null)
            {
                throw new NotValidException(nameof(request.OrderId),
                    $"Order with id ({request.OrderId}) doesn't exist");
            }

            order.OrderStatus = request.OrderStatus;
            order.DateShipped = request.DateShipped;
            if (request.DateShipped != null)
            {
                if (order.OrderStatus != OrderStatus.Completed)
                {
                    throw new NotValidException(nameof(request.OrderStatus),
                        "Only completed orders can have shipped date");
                }

                if (request.DateShipped < order.DateOrdered)
                {
                    throw new NotValidException(nameof(request.DateShipped),
                        "Date Shipped Should be later than date ordered");
                }

                order.DateShipped = request.DateShipped;
            }

            await _orderRepository.UnitOfWork.SaveChangesAsync();

            var result = _mapper.Map<OrderDto>(order);
            return result;
        }
    }
}