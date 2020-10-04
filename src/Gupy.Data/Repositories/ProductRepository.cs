using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gupy.Core.Common;
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

        public override Task<List<Product>> ListAsync(Specification<Product> specification = null)
        {
            var products = Context.Products.Include(p => p.Photo);

            return specification == null
                ? products.ToListAsync()
                : products.Where(specification.ToExpression()).ToListAsync();
        }

        public Task<Product> GetProductWithPhoto(int productId)
        {
            return Context.Products.Include(p => p.Photo).SingleOrDefaultAsync(p => p.Id == productId);
        }
    }
}