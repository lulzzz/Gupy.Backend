using System;
using System.Linq.Expressions;
using Gupy.Core.Common;
using Gupy.Domain;

namespace Gupy.Business.Specifications.Orders
{
    public class OrderOfUserSpecification : Specification<Order>
    {
        private readonly int _userId;

        public OrderOfUserSpecification(int userId)
        {
            _userId = userId;
        }

        public override Expression<Func<Order, bool>> ToExpression()
        {
            return order => order.ShippingDetails.TelegramUserId == _userId;
        }
    }
}