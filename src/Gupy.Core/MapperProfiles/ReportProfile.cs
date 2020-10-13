using AutoMapper;
using Gupy.Core.Dtos;
using Gupy.Domain;

namespace Gupy.Core.MapperProfiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<Report, ReportDto>();
            CreateMap<ReportDto, Report>()
                .ForMember(r => r.DateReported, cfg => cfg.Ignore());
        }
    }
}