using Gupy.Core.Common;
using Gupy.Domain;

namespace Gupy.Business.Specifications.Reports
{
    public class ReportFromUserSpecification : Specification<Report>
    {
        public ReportFromUserSpecification(int userId)
        {
            Expr = report => report.TelegramUserId == userId;
        }
    }
}