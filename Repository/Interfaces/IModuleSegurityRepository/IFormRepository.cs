using Entity.Dtos.ModuleSegurity;
using Entity.Models;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces.IModuleBaseRepository;

namespace Repository.Interfaces.IModuleSegurityRepository
{
  
    public interface IFormRepository : IBaseModelRepository<Form, FormDTO, FormRequest>
    {
    }
}
