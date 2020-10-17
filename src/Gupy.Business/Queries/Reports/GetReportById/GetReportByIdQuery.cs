using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Queries.Reports.GetReportById
{
    public class GetReportByIdQuery : IRequest<ReportDto>
    {
        public int Id { get; set; }
    }
}