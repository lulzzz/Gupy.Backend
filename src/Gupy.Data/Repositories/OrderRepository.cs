using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gupy.Core.Common;
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

        public override Task<List<Order>> ListAsync(Specification<Order> specification = null)
        {
            var orders = Context.Orders.Include(o => o.OrderItems)
                .Include(o => o.ShippingDetails).AsQueryable();

            if (specification == null)
            {
                return orders.ToListAsync();
            }

            return orders.Where(specification.ToExpression()).ToListAsync();
        }

        public Task<Order> GetOrderWithItems(int id)
        {
            return Context.Orders.Include(o => o.OrderItems).SingleOrDefaultAsync(o => o.Id == id);
        }
    }
}