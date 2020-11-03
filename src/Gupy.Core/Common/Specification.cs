using System;
using System.Linq.Expressions;

namespace Gupy.Core.Common
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T , bool>> ToExpression();
 
        public bool IsSatisfiedBy(T entity)
        {
            var predicate = ToExpression().Compile();
            return predicate(entity);
        }
    }
}