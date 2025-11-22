using AutoMapper;
using Entity.Dtos;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;

namespace Utilities.Mappers.ModuleSegurity
{
   
    public class RoleProfiles : Profile
    {
        public RoleProfiles() : base()
        {
       
            CreateMap<RoleDTO, Role>().ReverseMap();

          
            CreateMap<RoleRequest, Role>().ReverseMap();
        }
    }
}