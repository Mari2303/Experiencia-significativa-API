using Entity.Dtos.ModuleSegurity;
using Entity.Models;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces.IModuleSegurityRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.IModuleSegurityService;

namespace Service.Implementations.ModuleSegurityService
{
   
    public class FormService : BaseModelService<Form, FormDTO, FormRequest>,IFormService
    {
        private readonly IFormRepository _formRepository;

      
        public FormService(IFormRepository formRepository) : base(formRepository)
        {
            _formRepository = formRepository;
        }
    }
}
