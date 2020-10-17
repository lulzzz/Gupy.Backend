using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;

namespace Gupy.Data.Repositories
{
    public class PromotionRepository : Repository<Promotion>, IPromotionRepository
    {
        public PromotionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}