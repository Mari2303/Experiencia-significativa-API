using AutoMapper;
using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;

namespace Utilities.Mappers.ModuleSegurity
{
    

    public class UserRoleProfiles : Profile
    {
        public UserRoleProfiles() : base()
        {
         
            CreateMap<UserRoleDTO, UserRole>().ReverseMap();

            CreateMap<UserRoleRequest, UserRole>().ReverseMap();
        }
    }
}