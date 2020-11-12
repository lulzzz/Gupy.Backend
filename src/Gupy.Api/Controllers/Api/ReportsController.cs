using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Business.Commands.Reports;
using Gupy.Business.Queries.Reports;
using Gupy.Core.Dtos;
using HybridModelBinding;
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

        [HttpGet("{reportId:min(1)}")]
        public async Task<ActionResult<ReportDto>> GetReport([FromHybrid] GetReportByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ReportDto>>> GetReports([FromHybrid] GetReportsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ReportDto>> CreateReport([FromHybrid] CreateReportCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}