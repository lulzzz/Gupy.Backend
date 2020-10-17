using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Core.Dtos;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;
using MediatR;

namespace Gupy.Business.Commands.Orders.ChangerOrderStatus
{
    public class ChangeOrderStatusCommandHandler : IRequestHandler<ChangeOrderStatusCommand, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public ChangeOrderStatusCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderWithItems(request.OrderId);
            if (order == null)
            {
                throw new NotFoundException(nameof(request.OrderId),
                    $"Order with id ({request.OrderId}) doesn't exist");
            }

            order.OrderStatus = request.OrderStatus;
            if (request.OrderStatus == OrderStatus.Completed)
            {
                order.DateShipped = DateTime.UtcNow;
            }

            await _orderRepository.UnitOfWork.SaveChangesAsync();

            var result = _mapper.Map<OrderDto>(order);
            return result;
        }
    }
}