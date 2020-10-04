using System.Linq;
using Gupy.Core.Common;
using Gupy.Domain;

namespace Gupy.Business.Specifications
{
    public class CategoryHasProductsSpecification : Specification<Category>
    {
        public CategoryHasProductsSpecification(bool hasProducts)
        {
            if (hasProducts)
            {
                Expr = category => category.Products.Any();
                return;
            }

            Expr = category => !category.Products.Any();
        }
    }
}