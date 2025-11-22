using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace API.Controllers.ModuleOperationController
{
    public class InstitutionController : BaseModelController<Institution, InstitutionDTO, InstitutionRequest>
    {
        private readonly IInstitutionService _institutionService;
        private readonly IMapper _mapper;
        public InstitutionController(IBaseModelService<Institution, InstitutionDTO, InstitutionRequest> baseService, IInstitutionService institutionService, IMapper mapper) : base(baseService, mapper)
        {
            _institutionService = institutionService;
            _mapper = mapper;
        }
    }
}
