using System.Collections.Generic;
using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Queries.Report.GetReports
{
    public class GetReportsQuery : IRequest<List<ReportDto>>
    {
        public int? UserId { get; set; }
    }
}