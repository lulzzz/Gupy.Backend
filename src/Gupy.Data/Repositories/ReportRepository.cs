using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;

namespace Gupy.Data.Repositories
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}