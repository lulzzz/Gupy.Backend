using Gupy.Core.Dtos;
using MediatR;

namespace Gupy.Business.Queries.TelegramUsers.GetUserById
{
    public class GetUserByIdQuery : IRequest<TelegramUserDto>
    {
        public int telegramId { get; set; }
    }
}