using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Dtos.ModuleGeographic;
using Entity.Requests.ModuleGeographic;

namespace Utilities.Mappers.ModuleGeographic
{
    public class CommuneProfiles : Profile
    {
        public CommuneProfiles() : base()
        {
            CreateMap<CommuneDTO, CommuneRequest>().ReverseMap();
            CreateMap<CommuneRequest, CommuneDTO>().ReverseMap();
        }
    }
}
