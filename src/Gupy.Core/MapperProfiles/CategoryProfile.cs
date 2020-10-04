using AutoMapper;
using Gupy.Core.Dtos;
using Gupy.Domain;

namespace Gupy.Core.MapperProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(c => c.Photo,
                    cfg => cfg.MapFrom(c => c.Photo.FileName));
            CreateMap<CategoryDto, Category>()
                .ForMember(c => c.Photo,
                    cfg => cfg.Ignore());
        }
    }
}