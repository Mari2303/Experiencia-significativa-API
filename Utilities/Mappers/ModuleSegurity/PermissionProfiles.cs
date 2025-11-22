using AutoMapper;
using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;

namespace Utilities.Mappers.ModuleSegurity
{
   
    public class PermissionProfiles : Profile
    {
        public PermissionProfiles() : base()
        {
           
            CreateMap<PermissionDTO, Permission>().ReverseMap();

           
            CreateMap<PermissionRequest, Permission>().ReverseMap();
        }
    }
}