using System.Threading;
using System.Threading.Tasks;

namespace Gupy.Core.Interfaces.Data.UnitOfWork
{
    /// <summary>
    /// Unit Of Work
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves Changes Made In Db
        /// </summary>
        int SaveChanges();

        /// <summary>
        /// Saves Changes Made In Db
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}