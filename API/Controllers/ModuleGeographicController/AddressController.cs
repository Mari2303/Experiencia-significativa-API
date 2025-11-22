using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleGeographic;
using Entity.Models.ModuleGeographic;
using Entity.Requests.ModuleGeographic;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.IModuleGeographicService;

namespace API.Controllers.ModuleGeographicController
{
    public class AddressController : BaseModelController<Address, AddressDTO, AddressRequest>
    {

        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;


        public AddressController(IBaseModelService<Address, AddressDTO, AddressRequest> baseService,IAddressService addressService, IMapper mapper) : base(baseService, mapper)
        {

            _addressService = addressService;
            _mapper = mapper;
        }


    }
}
