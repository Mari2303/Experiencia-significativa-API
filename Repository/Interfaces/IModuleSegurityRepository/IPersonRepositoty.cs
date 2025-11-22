using Entity.Dtos.ModuleSegurity;
using Entity.Models;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces.IModuleBaseRepository;

namespace Repository.Interfaces.IModuleSegurityRepository
{
  
    public interface IPersonRepository : IBaseModelRepository<Person, PersonDTO, PersonRequest>
    {
        Task<User?> GetByIdAsync(int id);
    }
}