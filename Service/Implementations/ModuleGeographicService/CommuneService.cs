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
    public class CommuneService : BaseModelService<Commune, CommuneDTO, CommuneRequest>, ICommuneService
    {
       private readonly ICommuneRepository _communeRepository;
        public CommuneService(ICommuneRepository communeRepository) : base(communeRepository)
        {
            _communeRepository = communeRepository;
        }
    }
}
