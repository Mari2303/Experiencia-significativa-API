using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Dtos.ModelosParametro;
using Entity.Models.ModelosParametros;
using Entity.Requests.ModulesParamer;
using Microsoft.Identity.Client;

namespace Utilities.Mappers.ModulesParamer
{
    public  class PopulationGradeProfiles : Profile
    {


        public PopulationGradeProfiles() { 
        
        CreateMap<PopulationGradeDTO, PopulationGrade>().ReverseMap();

        CreateMap<PopulationGradeRequest,  PopulationGrade>().ReverseMap();

        
        
        }    

    }
}
