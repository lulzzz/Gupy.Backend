using Gupy.Core.Common;
using Gupy.Domain;

namespace Gupy.Business.Specifications.Products
{
    public class ProductHasPromotionSpecification : Specification<Product>
    {
        public ProductHasPromotionSpecification(bool hasPromotion)
        {
            Expr = product => product.Promotion != null == hasPromotion;
        }
    }
}