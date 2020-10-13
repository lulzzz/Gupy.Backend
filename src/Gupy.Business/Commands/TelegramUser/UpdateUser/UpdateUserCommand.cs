using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Commands.TelegramUser.UpdateUser
{
    public class UpdateUserCommand : IRequest<TelegramUserDto>
    {
        public TelegramUserDto TelegramUserDto { get; set; }
    }
}