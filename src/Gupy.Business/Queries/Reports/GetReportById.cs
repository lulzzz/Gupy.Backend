using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Core.Dtos;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Queries.Reports
{
    
    public class GetReportByIdQuery : IRequest<ReportDto>
    {
        public int ReportId { get; set; }
    }
    
    public class GetReportByIdQueryHandler : IRequestHandler<GetReportByIdQuery, ReportDto>
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public GetReportByIdQueryHandler(IReportRepository reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public async Task<ReportDto> Handle(GetReportByIdQuery request, CancellationToken cancellationToken)
        {
            var report = await _reportRepository.GetAsync(request.ReportId);
            if (report == null)
            {
                throw new NotFoundException(nameof(request.ReportId), $"Report with id ({request.ReportId}) does not exist");
            }

            var result = _mapper.Map<ReportDto>(report);
            return result;
        }
    }
}