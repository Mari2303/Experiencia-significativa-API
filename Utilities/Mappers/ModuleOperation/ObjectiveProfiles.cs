using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;

namespace Utilities.Mappers.ModuleOperation
{
    public class ObjectiveProfiles : Profile
    {
        public ObjectiveProfiles() : base()
        {
            CreateMap<ObjectiveDTO, Objective>().ReverseMap();
            CreateMap<ObjectiveRequest, Objective>().ReverseMap();
        }
    }
}
