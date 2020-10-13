using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;

namespace Gupy.Data.Repositories
{
    public class ShippingDetailsRepository : Repository<ShippingDetails>, IShippingDetailsRepository
    {
        public ShippingDetailsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}