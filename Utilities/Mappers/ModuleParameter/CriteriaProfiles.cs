using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Dtos.ModelosParametro;
using Entity.Models.ModelosParametros;
using Entity.Requests.ModuleParameter;

namespace Utilities.Mappers.ModulesParamer
{
    public class CriteriaProfiles : Profile
        
    {
        public CriteriaProfiles() {

            CreateMap<CriteriaDTO, Criteria>().ReverseMap();
            CreateMap<CriteriaRequest, Criteria>().ReverseMap();

        
        }
    }
}
