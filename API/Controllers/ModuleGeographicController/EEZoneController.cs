using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleGeographic;
using Entity.Models.ModuleGeographic;
using Entity.Requests.ModuleGeographic;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.IModuleGeographicService;

namespace API.Controllers.ModuleGeographicController
{
    public class EEZoneController : BaseModelController<EEZone, EEZoneDTO, EEZoneRequest>

    {

        private readonly IEEZoneService _eeZoneService;
        private readonly IMapper _mapper;

        public EEZoneController(IBaseModelService<EEZone, EEZoneDTO, EEZoneRequest> baseService,IEEZoneService eeZoneService, IMapper mapper) : base(baseService, mapper)
        {
            _eeZoneService = eeZoneService;
            _mapper = mapper;
        }
    }
}
