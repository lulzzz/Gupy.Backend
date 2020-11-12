using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Business.Commands.Details;
using Gupy.Business.Queries.Details;
using Gupy.Core.Dtos;
using Gupy.Domain;
using HybridModelBinding;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gupy.Api.Controllers.Api
{
    public class ShippingDetailsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ShippingDetailsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{shippingDetailsId:min(1)}")]
        public async Task<ActionResult<ShippingDetailsDto>> GetShippingDetails([FromHybrid] GetDetailsByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ShippingDetailsDto>>> GetShippingDetails([FromHybrid] GetDetailsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ShippingDetails>> CreateShippingDetails(
            [FromHybrid] CreateDetailsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{shippingDetailsId:min(1)}")]
        public async Task<ActionResult> DeleteShippingDetails([FromHybrid] DeleteDetailsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}