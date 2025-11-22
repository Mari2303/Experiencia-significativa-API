using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleSegurity;
using Entity.Models;
using Entity.Requests.ModuleSegurity;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.IModuleSegurityService;

namespace API.Controllers.ModuleSegurityController
{
    public class FormController : BaseModelController<Form, FormDTO, FormRequest>
    {
        private readonly IFormService _formService;
        private readonly IMapper _mapper;

        public FormController(IBaseModelService<Form, FormDTO, FormRequest> baseService, IFormService formService, IMapper mapper) : base(baseService, mapper)
        {
            _formService = formService;
            _mapper = mapper;
        }
    }
}