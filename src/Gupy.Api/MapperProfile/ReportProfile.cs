using AutoMapper;
using Gupy.Api.Models.Report;
using Gupy.Core.Dtos;

namespace Gupy.Api.MapperProfile
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<CreateReportModel, ReportDto>();
        }
    }
}