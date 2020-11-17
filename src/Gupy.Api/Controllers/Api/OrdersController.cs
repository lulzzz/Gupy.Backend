using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Api.Models.Order;
using Gupy.Business.Commands.Exports;
using Gupy.Business.Commands.Orders;
using Gupy.Business.Queries.Orders;
using Gupy.Core.Common;
using Gupy.Core.Dtos;
using Gupy.Core.Interfaces.Common;
using Gupy.Domain;
using HybridModelBinding;
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

        [HttpGet("{orderId:min(1)}")]
        public async Task<ActionResult<OrderDto>> GetOrder([FromHybrid] GetOrderByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetOrders([FromHybrid] GetOrdersQuery query)
        {
            var result = await _mediator.Send(query);
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

        [HttpPut("{orderId:min(1)}")]
        public async Task<ActionResult<OrderDto>> ChangeOrder([FromHybrid] ChangeOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("export")]
        public async Task<ActionResult<IFile>> ExportToExcel()
        {
            var result = await _mediator.Send(new ExportOrdersCommand());
            return File(result.FileContents,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                result.FileName);
        }
    }
}