using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;

namespace Utilities.Mappers.ModuleOperation
{
    public class ExperienceGradeProfiles : Profile
    {
        public ExperienceGradeProfiles() : base()
        {
            CreateMap<ExperienceGradeDTO, ExperienceGrade>().ReverseMap();
            CreateMap<ExperienceGradeRequest, ExperienceGrade>().ReverseMap();
        }
    }
}
