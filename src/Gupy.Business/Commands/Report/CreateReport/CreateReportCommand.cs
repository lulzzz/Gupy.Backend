using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Commands.Report.CreateReport
{
    public class CreateReportCommand : IRequest<ReportDto>
    {
        public ReportDto ReportDto { get; set; }
    }
}