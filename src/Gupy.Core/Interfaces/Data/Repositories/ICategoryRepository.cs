using System.Threading.Tasks;
using Gupy.Domain;

namespace Gupy.Core.Interfaces.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        /// <summary>
        /// Checks if category exists
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        ValueTask<bool> CategoryExists(int categoryId);

        /// <summary>
        /// Checks if category is exists
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        Task<bool> CategoryExists(string categoryName);

        /// <summary>
        /// Checks if category is unique
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns>False if more than one category with such name exists. True otherwise</returns>
        Task<bool> CategoryIsUnique(int categoryId, string categoryName);

        Task<Category> GetCategoryWithPhotoAsync(int categoryId);
    }
}