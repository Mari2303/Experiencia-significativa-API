

using AutoMapper;
using Entity.Dtos.ModuleOperation;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace Service.Implementations.ModelOperationService
{
    public class MonitoringService : BaseModelService<Monitoring, MonitoringDTO, MonitoringRequest>, IMonitoringService
    {

        private readonly IMonitoringRepository _monitoringRepository;
       
        public MonitoringService(IMonitoringRepository monitoringRepository, IMapper mapper) : base(monitoringRepository)
        {
            _monitoringRepository = monitoringRepository;
        }
    }
}
