using AutoMapper;
using Entity.Dtos;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;

namespace Utilities.Mappers.ModuleSegurity
{
   
    public class ModuleProfiles : Profile
    {

        public ModuleProfiles() : base()
        {

          
            CreateMap<ModuleDTO, Module>().ReverseMap();

           
            CreateMap<ModuleRequest, Module>().ReverseMap();
        }
    }
}