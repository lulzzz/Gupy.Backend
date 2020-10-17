using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Commands.TelegramUsers.UpdateUser
{
    public class UpdateUserCommand : IRequest<TelegramUserDto>
    {
        public TelegramUserDto TelegramUserDto { get; set; }
    }
}