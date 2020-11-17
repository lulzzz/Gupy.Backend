using FluentValidation;
using Gupy.Business.Commands.Details;

namespace Gupy.Api.Validators.ShippingDetails
{
    public class CreateShippingDetailsValidator : AbstractValidator<CreateDetailsCommand>
    {
        public CreateShippingDetailsValidator()
        {
            RuleFor(sd => sd.Address).MaximumLength(256);
            RuleFor(sd => sd.PhoneNumber).MaximumLength(64);
            RuleFor(sd => sd.ReceiverName).MaximumLength(256);
            RuleFor(sd => sd.TelegramUserId).GreaterThan(0);
        }
    }
}