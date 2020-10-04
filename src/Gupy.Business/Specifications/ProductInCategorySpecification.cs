using Gupy.Core.Common;
using Gupy.Domain;

namespace Gupy.Business.Specifications
{
    public class ProductInCategorySpecification : Specification<Product>
    {
        public ProductInCategorySpecification(int categoryId)
        {
            Expr = product => product.CategoryId == categoryId;
        }
    }
}