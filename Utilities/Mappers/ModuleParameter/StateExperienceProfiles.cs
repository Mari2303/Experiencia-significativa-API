using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Dtos.ModelosParametro;
using Entity.Models.ModelosParametros;
using Entity.Requests.ModulesParamer;

namespace Utilities.Mappers.ModulesParamer
{
    public class StateExperienceProfiles : Profile
    {
        public StateExperienceProfiles() { 
        
        
        CreateMap<StateExperienceDTO, StateExperience>().ReverseMap();

            CreateMap<StateExperienceRequest, StateExperience>().ReverseMap();
        
        }
    }
}
