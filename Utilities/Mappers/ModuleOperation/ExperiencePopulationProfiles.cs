

using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;

namespace Utilities.Mappers.ModuleOperation
{
    public class ExperiencePopulationProfiles : Profile
    {
        public ExperiencePopulationProfiles() : base()
        {

             CreateMap<ExperiencePopulationDTO,ExperiencePopulation>().ReverseMap();
            CreateMap<ExperiencePopulationRequest,ExperiencePopulation>().ReverseMap();




        }
    }
}
