using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;

namespace Utilities.Mappers.ModuleOperation
{
    public class HistoryExperienceProfiles : Profile
    {
        public HistoryExperienceProfiles() : base()
        {
             CreateMap<HistoryExperienceDTO, HistoryExperience>().ReverseMap();
             CreateMap<HistoryExperienceRequest, HistoryExperience>().ReverseMap();
        }
    }
}
