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
using Service.Interfaces;
using Service.Interfaces.IModuleGeographicService;

namespace Service.Implementations.ModuleGeographicService
{
    public class EEZoneService : BaseModelService<EEZone, EEZoneDTO, EEZoneRequest>, IEEZoneService
    {
        private readonly IEEZoneRepository _eeZoneRepository;

        public EEZoneService(IEEZoneRepository eeZoneRepository) : base(eeZoneRepository)
        {
            _eeZoneRepository = eeZoneRepository;
        }
    }
}
