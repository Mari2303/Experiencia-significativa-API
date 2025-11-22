using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleGeographic;
using Entity.Models.ModuleGeographic;
using Entity.Requests.ModuleGeographic;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.IModuleGeographicService;

namespace API.Controllers.ModuleGeographicController
{
    public class MunicipalityController : BaseModelController<Municipality, MunicipalityDTO, MunicipalityRequest>

    {

        private readonly IMunicipalityService _municipalityService;
        private readonly IMapper _mapper;


        public MunicipalityController(IBaseModelService<Municipality, MunicipalityDTO, MunicipalityRequest> baseService, IMunicipalityService municipalityService, IMapper mapper) : base(baseService, mapper)
        {
            _municipalityService = municipalityService;
            _mapper = mapper;
        }

    }
}
