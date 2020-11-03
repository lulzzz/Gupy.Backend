using System;
using System.Linq.Expressions;
using Gupy.Core.Common;
using Gupy.Domain;

namespace Gupy.Business.Specifications.Products
{
    public class ProductInCategorySpecification : Specification<Product>
    {
        private readonly int _categoryId;

        public ProductInCategorySpecification(int categoryId)
        {
            _categoryId = categoryId;
        }

        public override Expression<Func<Product, bool>> ToExpression()
        {
            return product => product.CategoryId == _categoryId;
        }
    }
}