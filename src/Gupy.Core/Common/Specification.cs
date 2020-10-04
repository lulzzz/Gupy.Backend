using System;
using System.Linq.Expressions;

namespace Gupy.Core.Common
{
    public abstract class Specification<T>
    {
        protected Expression<Func<T, bool>> Expr;

        public virtual Expression<Func<T, bool>> ToExpression() => Expr;

        public bool IsSatisfiedBy(T entity)
        {
            var predicate = ToExpression().Compile();
            return predicate(entity);
        }

        public Specification<T> And(Specification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }
    }
}