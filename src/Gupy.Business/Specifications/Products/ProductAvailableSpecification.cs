using Gupy.Core.Common;
using Gupy.Domain;

namespace Gupy.Business.Specifications.Products
{
    public class ProductAvailableSpecification : Specification<Product>
    {
        public ProductAvailableSpecification(bool isAvailable)
        {
            Expr = product => product.IsAvailable == isAvailable;
        }
    }
}