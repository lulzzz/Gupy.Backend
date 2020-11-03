using System;
using System.Linq.Expressions;
using Gupy.Core.Common;
using Gupy.Domain;

namespace Gupy.Business.Specifications.Products
{
    public class ProductAvailableSpecification : Specification<Product>
    {
        private readonly bool _isAvailable;

        public ProductAvailableSpecification(bool isAvailable)
        {
            _isAvailable = isAvailable;
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return product => product.IsAvailable == _isAvailable;
        }
    }
}