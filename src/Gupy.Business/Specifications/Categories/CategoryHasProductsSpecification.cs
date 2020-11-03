using System;
using System.Linq;
using System.Linq.Expressions;
using Gupy.Core.Common;
using Gupy.Domain;

namespace Gupy.Business.Specifications.Categories
{
    public class CategoryHasProductsSpecification : Specification<Category>
    {
        private readonly bool _hasProducts;

        public CategoryHasProductsSpecification(bool hasProducts)
        {
            _hasProducts = hasProducts;
        }

        public override Expression<Func<Category, bool>> ToExpression()
        {
            return category => category.Products.Any() == _hasProducts;
        }
    }
}