using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gupy.Core.Common;
using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;
using Microsoft.EntityFrameworkCore;

namespace Gupy.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async ValueTask<bool> CategoryExists(int categoryId)
        {
            var result = await GetAsync(categoryId) != null;
            return result;
        }

        public async Task<bool> CategoryExists(string categoryName)
        {
            var categories = await FindAsync(c => c.Name == categoryName);
            var result = categories.Count != 0;
            return result;
        }

        public async Task<bool> CategoryIsUnique(int categoryId, string categoryName)
        {
            var result = await FindAsync(c => c.Name == categoryName && c.Id != categoryId);
            return !result.Any();
        }

        public Task<Category> GetCategoryWithPhotoAsync(int categoryId)
        {
            return CategoriesWithPhotos().SingleOrDefaultAsync(c => c.Id == categoryId);
        }

        public override Task<List<Category>> ListAsync(Specification<Category> specification = null)
        {
            var categories = Context.Categories.Include(c => c.Photo);

            if (specification == null)
            {
                return categories.ToListAsync();
            }

            return categories.Where(specification.ToExpression()).ToListAsync();
        }

        private IQueryable<Category> CategoriesWithPhotos()
        {
            return Context.Categories.Include(c => c.Photo).AsQueryable();
        }
    }
}