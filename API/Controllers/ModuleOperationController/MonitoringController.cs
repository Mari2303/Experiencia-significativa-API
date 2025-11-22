using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleOperation;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace API.Controllers.ModuleOperationController
{
    public class MonitoringController : BaseModelController<Monitoring, MonitoringDTO, MonitoringRequest>
    {

        private readonly IMonitoringService _monitoringService;
        private readonly IMapper _mapper;

        public MonitoringController(IBaseModelService<Monitoring, MonitoringDTO, MonitoringRequest> baseService,IMonitoringService monitoringService, IMapper mapper) : base(baseService, mapper)
        {
            _monitoringService = monitoringService;
            _mapper = mapper;
        }
    }
}
