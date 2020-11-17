using FluentValidation;
using Gupy.Business.Commands.TelegramUsers;

namespace Gupy.Api.Validators.User
{
    public class UpdateTgUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateTgUserValidator()
        {
            RuleFor(u => u.TelegramUserDto.TelegramId).GreaterThan(0);
            RuleFor(u => u.TelegramUserDto.UserName).MaximumLength(64);
            RuleFor(u => u.TelegramUserDto.PhoneNumber).MaximumLength(64);
        }
    }
}