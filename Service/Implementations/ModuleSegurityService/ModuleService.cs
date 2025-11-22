using Entity.Dtos;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces.IModuleSegurityRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.IModuleSegurityService;

namespace Service.Implementations.ModuleSegurityService
{
    
    public class ModuleService : BaseModelService<Module, ModuleDTO, ModuleRequest>, IModuleService
    {
        private readonly IBaseModuleRepository _moduleRepository;

     
        public ModuleService(IBaseModuleRepository moduleRepository) : base(moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }
    }
}
