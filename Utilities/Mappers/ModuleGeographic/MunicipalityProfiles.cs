using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Dtos.ModuleGeographic;
using Entity.Models.ModuleGeographic;
using Entity.Requests.ModuleGeographic;

namespace Utilities.Mappers.ModuleGeographic
{
    public class MunicipalityProfiles : Profile
    {
        public MunicipalityProfiles() : base() 
        {
              CreateMap<MunicipalityDTO, Municipality>().ReverseMap();
              CreateMap<MunicipalityRequest, Municipality>().ReverseMap();
        }
    }
}
