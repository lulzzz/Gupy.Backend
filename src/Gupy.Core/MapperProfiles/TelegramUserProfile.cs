using AutoMapper;
using Gupy.Core.Dtos;
using Gupy.Domain;

namespace Gupy.Core.MapperProfiles
{
    public class TelegramUserProfile : Profile
    {
        public TelegramUserProfile()
        {
            CreateMap<TelegramUser, TelegramUserDto>();
            CreateMap<TelegramUserDto, TelegramUser>()
                .ForMember(u => u.DateJoined, cfg => cfg.Ignore());
        }
    }
}