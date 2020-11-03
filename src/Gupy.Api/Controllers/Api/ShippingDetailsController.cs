using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Api.Models.ShippingDetails;
using Gupy.Business.Commands.Details;
using Gupy.Business.Queries.Details;
using Gupy.Business.Queries.Details.GetDetailsById;
using Gupy.Core.Dtos;
using Gupy.Domain;
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

        [HttpGet("{id:min(1)}")]
        public async Task<ActionResult<ShippingDetailsDto>> GetShippingDetails([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetDetailsByIdQuery {ShippingDetailsId = id});
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ShippingDetailsDto>>> GetShippingDetails([FromQuery] int? userId)
        {
            var result = await _mediator.Send(new GetDetailsQuery {TelegramUserId = userId});
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ShippingDetails>> CreateShippingDetails(
            [FromBody] CreateDetailsModel detailsModel)
        {
            var result = await _mediator.Send(new CreateDetailsCommand
            {
                ShippingDetailsDto = _mapper.Map<ShippingDetailsDto>(detailsModel)
            });
            return Ok(result);
        }

        [HttpDelete("{id:min(1)}")]
        public async Task<ActionResult> DeleteShippingDetails([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteDetailsCommand
            {
                ShippingDetailsId = id
            });
            return Ok(result);
        }
    }
}