using System.Linq;
using System.Threading.Tasks;
using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;

namespace Gupy.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async ValueTask<bool> CategoryExists(int categoryId) => await GetAsync(categoryId) != null;

        public async Task<bool> CategoryExists(string categoryName)
        {
            var categories = await FindAsync(c => c.Name == categoryName);
            return categories.Count != 0;
        }

        public async Task<bool> CategoryIsUnique(int categoryId, string categoryName)
        {
            var result = await FindAsync(c => c.Name == categoryName && c.Id != categoryId);
            return !result.Any();
        }
    }
}