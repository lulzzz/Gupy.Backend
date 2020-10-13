using AutoMapper;
using Gupy.Api.Models.TelegramUser;
using Gupy.Core.Dtos;

namespace Gupy.Api.MapperProfile
{
    public class TelegramUserProfile : Profile
    {
        public TelegramUserProfile()
        {
            CreateMap<CreateUserModel, TelegramUserDto>();
            CreateMap<UpdateUserModel, TelegramUserDto>();
        }
    }
}