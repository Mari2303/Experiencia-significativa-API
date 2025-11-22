using AutoMapper;
using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;

namespace Utilities.Mappers.ModuleSegurity
{
  
    public class RoleFormPermissionProfiles : Profile
    {
        public RoleFormPermissionProfiles() : base()
        {

            CreateMap<RoleFormPermissionDTO, RoleFormPermission>().ReverseMap();

            
            CreateMap<RoleFormPermissionRequest, RoleFormPermission>().ReverseMap();
        }
    }
}