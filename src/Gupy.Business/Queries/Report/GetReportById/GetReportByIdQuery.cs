using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Queries.GetReportById
{
    public class GetReportByIdQuery : IRequest<ReportDto>
    {
        public int Id { get; set; }
    }
}