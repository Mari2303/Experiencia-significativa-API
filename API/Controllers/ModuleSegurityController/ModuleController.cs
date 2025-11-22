using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.IModuleSegurityService;

namespace API.Controllers.ModuleSegurityController
{
    public class ModuleController : BaseModelController<Module, ModuleDTO, ModuleRequest>
    {
        private readonly IModuleService _moduleService;
        private readonly IMapper _mapper;

        public ModuleController(IBaseModelService<Module, ModuleDTO, ModuleRequest> baseService, IModuleService service, IMapper mapper) : base(baseService, mapper)
        {
            _moduleService = service;
            _mapper = mapper;
        }
    }
}
