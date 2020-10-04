using Gupy.Core.Common;
using Gupy.Domain;

namespace Gupy.Business.Specifications
{
    public class ProductAvailableSpecification : Specification<Product>
    {
        public ProductAvailableSpecification(bool isAvailable)
        {
            Expr = product => product.IsAvailable == isAvailable;
        }
    }
}