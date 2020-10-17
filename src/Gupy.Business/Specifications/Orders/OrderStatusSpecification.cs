using Gupy.Core.Common;
using Gupy.Domain;

namespace Gupy.Business.Specifications.Orders
{
    public class OrderStatusSpecification : Specification<Order>
    {
        public OrderStatusSpecification(OrderStatus status)
        {
            Expr = order => order.OrderStatus == status;
        }
    }
}