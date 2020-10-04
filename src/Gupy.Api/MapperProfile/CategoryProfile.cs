using AutoMapper;
using Gupy.Api.Models.Category;
using Gupy.Core.Dtos;

namespace Gupy.Api.MapperProfile
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<UpdateCategoryModel, CategoryDto>()
                .ForMember(c => c.Photo, cfg => cfg.Ignore());
        }
    }
}