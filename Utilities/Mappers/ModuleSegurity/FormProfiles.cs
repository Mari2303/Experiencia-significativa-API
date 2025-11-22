using AutoMapper;
using Entity.Dtos.ModuleSegurity;
using Entity.Models;
using Entity.Requests.ModuleSegurity;

namespace Utilities.Mappers.ModuleSegurity
{
    
    public class FormProfiles : Profile
    {
        public FormProfiles() : base()
        {

        
            CreateMap<FormDTO, Form>().ReverseMap();

          
            CreateMap<FormRequest, Form>().ReverseMap();
        }
    }
}