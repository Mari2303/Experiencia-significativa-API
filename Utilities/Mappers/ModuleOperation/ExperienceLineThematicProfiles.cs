using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;

namespace Utilities.Mappers.ModuleOperation
{
    public class ExperienceLineThematicProfiles : Profile
    { 
        public ExperienceLineThematicProfiles() : base()
        {
            CreateMap<ExperienceLineThematicDTO, ExperienceLineThematic>().ReverseMap();
            CreateMap<ExperienceLineThematicRequest, ExperienceLineThematic>().ReverseMap();
        }
    }
}
