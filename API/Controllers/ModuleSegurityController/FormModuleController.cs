using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.IModuleSegurityService;

namespace API.Controllers
{
    public class FormModuleController : BaseModelController<FormModule, FormModuleDTO, FormModuleRequest>
    {
        private readonly IFormModuleService _formModuleService;
        private readonly IMapper _mapper;

        public FormModuleController(IBaseModelService<FormModule, FormModuleDTO, FormModuleRequest> baseService, IFormModuleService formModuleService, IMapper mapper) : base(baseService, mapper)
        {
            _formModuleService = formModuleService;
            _mapper = mapper;
        }
    }
}
