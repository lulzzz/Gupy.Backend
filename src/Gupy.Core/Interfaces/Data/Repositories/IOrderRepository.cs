using System.Threading.Tasks;
using Gupy.Domain;

namespace Gupy.Core.Interfaces.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetOrderWithItems(int id);
    }
}