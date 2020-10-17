using System.Threading.Tasks;
using Gupy.Domain;

namespace Gupy.Core.Interfaces.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductWithPromotionAsync(int productId);
    }
}