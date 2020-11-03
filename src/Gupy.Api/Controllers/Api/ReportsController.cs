using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Api.Models.Report;
using Gupy.Business.Commands.Reports;
using Gupy.Business.Queries.Reports;
using Gupy.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gupy.Api.Controllers.Api
{
    public class ReportsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ReportsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id:min(1)}")]
        public async Task<ActionResult<ReportDto>> GetReport([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetReportByIdQuery {Id = id});
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ReportDto>>> GetReports([FromQuery] int? userId)
        {
            var result = await _mediator.Send(new GetReportsQuery {UserId = userId});
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ReportDto>> CreateReport([FromBody] CreateReportModel reportModel)
        {
            var result = await _mediator.Send(new CreateReportCommand
            {
                ReportDto = _mapper.Map<ReportDto>(reportModel)
            });
            return Ok(result);
        }
    }
}