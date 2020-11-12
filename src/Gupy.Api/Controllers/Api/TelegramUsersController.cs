using System.Threading.Tasks;
using AutoMapper;
using Gupy.Api.Models.TelegramUser;
using Gupy.Business.Commands.TelegramUsers;
using Gupy.Business.Queries.TelegramUsers;
using Gupy.Core.Dtos;
using HybridModelBinding;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gupy.Api.Controllers.Api
{
    public class TelegramUsersController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TelegramUsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{telegramUserId:min(1)}")]
        public async Task<ActionResult<TelegramUserDto>> GetUser([FromHybrid] GetUserByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TelegramUserDto>> CreateUser([FromHybrid] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<TelegramUserDto>> UpdateUser([FromBody] UpdateUserModel userModel)
        {
            var result = await _mediator.Send(new UpdateUserCommand
            {
                TelegramUserDto = _mapper.Map<TelegramUserDto>(userModel)
            });
            return Ok(result);
        }
    }
}