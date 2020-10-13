using Gupy.Core.Common;
using Gupy.Domain;

namespace Gupy.Business.Specifications
{
    public class ShippingDetailsOfUserSpecification : Specification<ShippingDetails>
    {
        public ShippingDetailsOfUserSpecification(int userId)
        {
            Expr = details => details.TelegramUserId == userId;
        }
    }
}