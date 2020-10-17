using System.Linq;
using System.Threading.Tasks;
using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;
using Microsoft.EntityFrameworkCore;

namespace Gupy.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        protected override IQueryable<Order> IncludeChildren(IQueryable<Order> entities)
        {
            entities = entities.Include(o => o.OrderItems);
            return base.IncludeChildren(entities);
        }

        public Task<Order> GetOrderWithItems(int id)
        {
            return Context.Orders.Include(o => o.OrderItems).SingleOrDefaultAsync(o => o.Id == id);
        }
    }
}