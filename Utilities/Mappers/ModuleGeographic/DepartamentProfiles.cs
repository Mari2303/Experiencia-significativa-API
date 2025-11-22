using AutoMapper;
using Entity.Dtos.ModuleGeographic;
using Entity.Models.ModuleGeographic;
using Entity.Requests.ModuleGeographic;

namespace Utilities.Mappers.ModuleGeographic
{
    public class DepartamentProfiles : Profile
    {
        public DepartamentProfiles() : base()
        {
            CreateMap<DepartamentDTO, Departament>().ReverseMap();
            CreateMap<DepartamentRequest, Departament>().ReverseMap();
        }
    }
}
