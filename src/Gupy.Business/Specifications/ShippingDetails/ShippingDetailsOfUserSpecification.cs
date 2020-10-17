using Gupy.Core.Common;

namespace Gupy.Business.Specifications.ShippingDetails
{
    public class ShippingDetailsOfUserSpecification : Specification<Domain.ShippingDetails>
    {
        public ShippingDetailsOfUserSpecification(int userId)
        {
            Expr = details => details.TelegramUserId == userId;
        }
    }
}