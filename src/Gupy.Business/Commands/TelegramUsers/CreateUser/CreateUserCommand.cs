using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Commands.TelegramUsers.CreateUser
{
    public class CreateUserCommand : IRequest<TelegramUserDto>
    {
        public TelegramUserDto TelegramUserDto { get; set; }
    }
}