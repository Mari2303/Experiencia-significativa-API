using Entity.Dtos.ModuleGeographic;
using Entity.Models.ModuleGeographic;
using Entity.Requests.ModuleGeographic;
using Repository.Interfaces.IModuleBaseRepository;

namespace Repository.Interfaces.IModuleGeographicRepository
{
    public interface IEEZoneRepository : IBaseModelRepository<EEZone, EEZoneDTO, EEZoneRequest>
    {
    }
}
