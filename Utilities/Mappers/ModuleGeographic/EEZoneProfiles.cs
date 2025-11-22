using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Dtos.ModuleGeographic;
using Entity.Models.ModuleGeographic;
using Entity.Requests.ModuleGeographic;
using Microsoft.Identity.Client;

namespace Utilities.Mappers.ModuleGeographic
{
    public class EEZoneProfiles : Profile
    {
        public EEZoneProfiles() : base()
        {
           
                CreateMap<EEZoneDTO, EEZone>().ReverseMap();
                CreateMap<EEZoneRequest, EEZone>().ReverseMap();
            
        }
    }
}
