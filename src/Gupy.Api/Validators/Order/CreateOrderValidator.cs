using FluentValidation;
using Gupy.Api.Models.Order;

namespace Gupy.Api.Validators.Order
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderModel>
    {
        public CreateOrderValidator()
        {
            RuleFor(o => o.ShippingDetailsId).GreaterThan(0);
        }
    }
}