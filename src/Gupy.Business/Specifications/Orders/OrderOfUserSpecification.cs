using Gupy.Core.Common;
using Gupy.Domain;

namespace Gupy.Business.Specifications.Orders
{
    public class OrderOfUserSpecification : Specification<Order>
    {
        public OrderOfUserSpecification(int userId)
        {
            Expr = order => order.ShippingDetails.TelegramUserId == userId;
        }
    }
}