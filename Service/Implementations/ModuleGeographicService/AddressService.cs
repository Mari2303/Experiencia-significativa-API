using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.ModuleGeographic;
using Entity.Models.ModuleGeographic;
using Entity.Requests.ModuleGeographic;
using Repository.Interfaces.IModuleGeographicRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.IModuleGeographicService;

namespace Service.Implementations.ModuleGeographicService
{
    public  class AddressService : BaseModelService<Address, AddressDTO, AddressRequest>, IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository) : base(addressRepository)
        {
            _addressRepository = addressRepository;
        }
    }
}
