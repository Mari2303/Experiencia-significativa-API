using AutoMapper;
using Entity.Dtos.ModuleOperation;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;

namespace Utilities.Mappers.ModuleOperation
{
    public class DevelopmentProfiles : Profile
    {
        public DevelopmentProfiles() : base()
        {
            CreateMap<DevelopmentDTO, Development>().ReverseMap();
            CreateMap<DevelopmentRequest, Development>().ReverseMap();
        }
    }
}
