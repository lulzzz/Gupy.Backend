using Gupy.Core.Common;
using Gupy.Domain;

namespace Gupy.Business.Specifications
{
    public class ReportFromUserSpecification : Specification<Report>
    {
        public ReportFromUserSpecification(int userId)
        {
            Expr = report => report.TelegramUserId == userId;
        }
    }
}