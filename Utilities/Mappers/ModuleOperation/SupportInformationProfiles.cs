using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Dtos.ModuleOperation;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;

namespace Utilities.Mappers.ModuleOperation
{
    public class SupportInformationProfiles : Profile
    {
        public SupportInformationProfiles() : base()
        {
            CreateMap<SupportInformationDTO, SupportInformation>().ReverseMap();
            CreateMap<SupportInformationRequest, SupportInformation>().ReverseMap();
        }
    }
}
