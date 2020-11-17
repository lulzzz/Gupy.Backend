using System;
using FluentValidation;
using Gupy.Business.Commands.Orders;

namespace Gupy.Api.Validators.Order
{
    public class UpdateOrderValidator : AbstractValidator<ChangeOrderCommand>
    {
        public UpdateOrderValidator()
        {
            RuleFor(o => o.DateShipped).GreaterThanOrEqualTo(DateTime.Today);
            RuleFor(o => o.OrderId).GreaterThan(0);
            RuleFor(o => o.OrderStatus).IsInEnum();
        }
    }
}