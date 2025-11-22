using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Service.Interfaces.IModuleBaseService;

namespace Service.Interfaces.IModuleSegurityService
{

    public interface IPersonService : IBaseModelService<Person, PersonDTO, PersonRequest>
    {
        Task<UserRegisterResponseRequest> CreatePersonAsync(UserRegisterRequest request);
    }
}