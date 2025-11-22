using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleOperation;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace API.Controllers.ModuleOperationController
{
    public class SupportInformationController : BaseModelController<SupportInformation, SupportInformationDTO, SupportInformationRequest>
    {
        private readonly ISupportInformationService _supportInformationService;
        private readonly IMapper _mapper;

        public SupportInformationController(IBaseModelService<SupportInformation, SupportInformationDTO, SupportInformationRequest> baseService, ISupportInformationService service, IMapper mapper) : base(baseService, mapper)
        {
            _supportInformationService = service;
            _mapper = mapper;
        }
    }
}
