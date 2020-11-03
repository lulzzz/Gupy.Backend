using System;
using System.Linq.Expressions;
using Gupy.Core.Common;

namespace Gupy.Business.Specifications.ShippingDetails
{
    public class ShippingDetailsOfUserSpecification : Specification<Domain.ShippingDetails>
    {
        private readonly int _userId;

        public ShippingDetailsOfUserSpecification(int userId)
        {
            _userId = userId;
        }

        public override Expression<Func<Domain.ShippingDetails, bool>> ToExpression()
        {
            return details => details.TelegramUserId == _userId;
        }
    }
}