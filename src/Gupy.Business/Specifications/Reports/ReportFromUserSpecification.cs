using System;
using System.Linq.Expressions;
using Gupy.Core.Common;
using Gupy.Domain;

namespace Gupy.Business.Specifications.Reports
{
    public class ReportFromUserSpecification : Specification<Report>
    {
        private readonly int _userId;

        public ReportFromUserSpecification(int userId)
        {
            _userId = userId;
        }

        public override Expression<Func<Report, bool>> ToExpression()
        {
            return report => report.TelegramUserId == _userId;
        }
    }
}