using FluentValidation;
using Gupy.Business.Commands.TelegramUsers;

namespace Gupy.Api.Validators.User
{
    public class CreateTgUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateTgUserValidator()
        {
            RuleFor(u => u.TelegramId).GreaterThan(0);
            RuleFor(u => u.UserName).MaximumLength(64);
            RuleFor(u => u.PhoneNumber).MaximumLength(64);
        }
    }
}