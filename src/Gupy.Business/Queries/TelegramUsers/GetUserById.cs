using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Core.Dtos;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Queries.TelegramUsers
{
    public class GetUserByIdQuery : IRequest<TelegramUserDto>
    {
        public int TelegramUserId { get; set; }
    }
    
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, TelegramUserDto>
    {
        private readonly ITelegramUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(ITelegramUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<TelegramUserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.TelegramUserId);
            if (user == null)
            {
                throw new NotFoundException(nameof(request.TelegramUserId),
                    $"Telegram User with telegramId ({request.TelegramUserId}) does not exist");
            }

            var response = _mapper.Map<TelegramUserDto>(user);
            return response;
        }
    }
}