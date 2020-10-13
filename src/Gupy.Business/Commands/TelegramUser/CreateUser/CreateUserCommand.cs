using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<TelegramUserDto>
    {
        public TelegramUserDto TelegramUserDto { get; set; }
    }
}