using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Api.Models.Order;
using Gupy.Business.Commands.Orders.ChangerOrderStatus;
using Gupy.Business.Commands.Orders.CreateOrder;
using Gupy.Business.Queries.Orders.GetOrderById;
using Gupy.Business.Queries.Orders.GetOrders;
using Gupy.Core.Dtos;
using Gupy.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gupy.Api.Controllers.Api
{
    public class OrdersController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrdersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id:min(1)}")]
        public async Task<ActionResult<OrderDto>> GetOrder([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery
            {
                OrderId = id
            });
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetOrders([FromQuery] int? userId,
            [FromQuery] OrderStatus? orderStatus)
        {
            var result = await _mediator.Send(new GetOrdersQuery
            {
                TelegramUserId = userId, OrderStatus = orderStatus
            });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] CreateOrderModel orderModel)
        {
            var result = await _mediator.Send(new CreateOrderCommand
            {
                OrderDto = _mapper.Map<OrderDto>(orderModel)
            });
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<OrderDto>> ChangeOrderStatus([FromBody] UpdateOrderStatusModel statusModel)
        {
            var result = await _mediator.Send(new ChangeOrderStatusCommand
            {
                OrderId = statusModel.OrderId, OrderStatus = statusModel.OrderStatus
            });
            return Ok(result);
        }
    }
}