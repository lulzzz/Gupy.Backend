using System;
using System.Linq.Expressions;
using Gupy.Core.Common;
using Gupy.Domain;

namespace Gupy.Business.Specifications.Orders
{
    public class OrderStatusSpecification : Specification<Order>
    {
        private readonly OrderStatus _status;

        public OrderStatusSpecification(OrderStatus status)
        {
            _status = status;
        }

        public override Expression<Func<Order, bool>> ToExpression()
        {
            return order => order.OrderStatus == _status;
        }
    }
}