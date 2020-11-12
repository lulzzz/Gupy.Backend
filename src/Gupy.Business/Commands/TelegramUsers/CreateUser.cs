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
        public int TelegramId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
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
            var user = new TelegramUser
            {
                TelegramId = request.TelegramId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                DateJoined = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
            await _userRepository.UnitOfWork.SaveChangesAsync();

            var result = _mapper.Map<TelegramUserDto>(user);
            return result;
        }
    }
}