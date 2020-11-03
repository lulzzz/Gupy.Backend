using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;

namespace Gupy.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}