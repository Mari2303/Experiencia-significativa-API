using Entity.Dtos;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces.IModuleBaseRepository;

namespace Repository.Interfaces.IModuleSegurityRepository
{
   
   
    public interface IBaseModuleRepository : IBaseModelRepository<Module, ModuleDTO, ModuleRequest>
    {

    }
}
