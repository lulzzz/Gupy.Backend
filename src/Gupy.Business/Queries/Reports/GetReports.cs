using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Business.Specifications.Reports;
using Gupy.Core.Common;
using Gupy.Core.Dtos;
using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;
using MediatR;

namespace Gupy.Business.Queries.Reports
{
    public class GetReportsQuery : IRequest<List<ReportDto>>
    {
        public int? UserId { get; set; }
    }

    public class GetReportsQueryHandler : IRequestHandler<GetReportsQuery, List<ReportDto>>
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public GetReportsQueryHandler(IReportRepository reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public async Task<List<ReportDto>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
        {
            var specifications = new List<Specification<Report>>();
            if (request.UserId != null)
            {
                specifications.Add(new ReportFromUserSpecification(request.UserId.Value));
            }

            var reports = await _reportRepository.ListAsync(specifications: specifications.ToArray());

            var result = _mapper.Map<List<ReportDto>>(reports);
            return result;
        }
    }
}