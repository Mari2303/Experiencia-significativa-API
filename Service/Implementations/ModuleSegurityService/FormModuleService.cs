using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces.IModuleSegurityRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.IModuleSegurityService;

namespace Service.Implementations.ModuleSegurityService
{
   
    public class FormModuleService : BaseModelService<FormModule, FormModuleDTO, FormModuleRequest>, IFormModuleService
    {
        private readonly IFormModuleRepository _formModuleRepository;

        public FormModuleService(IFormModuleRepository formModuleRepository) : base(formModuleRepository)
        {
            _formModuleRepository = formModuleRepository;
        }

    }
}
