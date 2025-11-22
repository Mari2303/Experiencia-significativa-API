using AutoMapper;
using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;

namespace Utilities.Mappers.ModuleSegurity
{
   
    public class FormModuleProfiles : Profile
    {
        public FormModuleProfiles() : base()
        {
          
            CreateMap<FormModuleDTO, FormModule>().ReverseMap();

           
            CreateMap<FormModuleRequest, FormModule>().ReverseMap();
        }
    }
}