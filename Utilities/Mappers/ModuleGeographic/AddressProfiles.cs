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
    public class AddressProfiles : Profile
    {
        public AddressProfiles() : base()
        {
            CreateMap<AddressDTO, Address>().ReverseMap();
            CreateMap<AddressRequest, Address>().ReverseMap();
        }   
    }
}
