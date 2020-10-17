using System.Linq;
using System.Threading.Tasks;
using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;
using Microsoft.EntityFrameworkCore;

namespace Gupy.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<Product> GetProductWithPromotionAsync(int productId)
        {
            return Context.Products.Include(p => p.Promotion).SingleOrDefaultAsync(p => p.Id == productId);
        }

        protected override IQueryable<Product> IncludeChildren(IQueryable<Product> entities)
        {
            entities = entities.Include(p => p.Promotion);
            return base.IncludeChildren(entities);
        }
    }
}