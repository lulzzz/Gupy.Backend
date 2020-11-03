using System;
using System.Linq.Expressions;
using Gupy.Core.Common;
using Gupy.Domain;

namespace Gupy.Business.Specifications.Products
{
    public class ProductHasPromotionSpecification : Specification<Product>
    {
        private readonly bool _hasPromotion;

        public ProductHasPromotionSpecification(bool hasPromotion)
        {
            _hasPromotion = hasPromotion;
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return product => product.PromotionPrice != null == _hasPromotion;
        }
    }
}