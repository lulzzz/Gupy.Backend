using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Gupy.Core.Dtos;
using Gupy.Core.Exceptions;
using Gupy.Core.Interfaces.Data.Repositories;
using MediatR;

namespace Gupy.Business.Commands.TelegramUsers
{
    public class UpdateUserCommand : IRequest<TelegramUserDto>
    {
        public TelegramUserDto TelegramUserDto { get; set; }
    }
    
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, TelegramUserDto>
    {
        private readonly ITelegramUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(ITelegramUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<TelegramUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userDto = request.TelegramUserDto;
            var user = await _userRepository.GetAsync(userDto.Id);
            if (user == null)
            {
                throw new NotValidException(nameof(userDto.Id), $"User with id ({userDto.Id}) does not exist");
            }

            _mapper.Map(userDto, user);
            await _userRepository.UnitOfWork.SaveChangesAsync();

            var result = _mapper.Map<TelegramUserDto>(user);
            return result;
        }
    }
}