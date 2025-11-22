using Entity.Dtos;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Service.Interfaces.IModuleBaseService;

namespace Service.Interfaces.IModuleSegurityService
{
   
    public interface IModuleService : IBaseModelService<Module, ModuleDTO, ModuleRequest>
    {
    }
}
