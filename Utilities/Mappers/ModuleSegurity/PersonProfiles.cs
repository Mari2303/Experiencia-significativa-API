using AutoMapper;
using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;

namespace Utilities.Mappers.ModuleSegurity
{
    
    public class PersonProfiles : Profile
    {
        public PersonProfiles() : base()
        {
            
            CreateMap<PersonDTO, Person>().ReverseMap();

            CreateMap<PersonRequest, Person>().ReverseMap();
        }
    }
}