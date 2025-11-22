using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;

namespace Utilities.Mappers.ModuleOperation
{
    public class ExperienceProfiles : Profile
    {
        public ExperienceProfiles() : base()
        {
            CreateMap<ExperienceDTO, Experience>().ReverseMap();
            CreateMap<ExperienceRequest, Experience>().ReverseMap();


            CreateMap<Experience, ExperienceRequest>()
    .ForMember(dest => dest.StateExperience,
               opt => opt.MapFrom(src => src.StateExperience.Name));

        }
    }
}
