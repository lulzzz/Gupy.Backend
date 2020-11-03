using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Core.Dtos;
using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Domain;
using MediatR;

namespace Gupy.Business.Commands.TelegramUsers
{
    public class CreateUserCommand : IRequest<TelegramUserDto>
    {
        public TelegramUserDto TelegramUserDto { get; set; }
    }
    
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, TelegramUserDto>
    {
        private readonly ITelegramUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(ITelegramUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<TelegramUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<TelegramUser>(request.TelegramUserDto);
            user.DateJoined = DateTime.UtcNow;

            await _userRepository.AddAsync(user);
            await _userRepository.UnitOfWork.SaveChangesAsync();

            var result = _mapper.Map<TelegramUserDto>(user);
            return result;
        }
    }
}