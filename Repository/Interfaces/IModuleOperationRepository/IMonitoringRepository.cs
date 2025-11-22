using Entity.Dtos.ModuleOperation;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Repository.Interfaces.IModuleBaseRepository;

namespace Repository.Interfaces.IModuleOperationRepository
{
    public interface IMonitoringRepository : IBaseModelRepository<Monitoring, MonitoringDTO, MonitoringRequest>
    {
    }
}
