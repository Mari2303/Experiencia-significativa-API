using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleGeographic;
using Entity.Models.ModuleGeographic;
using Entity.Requests.ModuleGeographic;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.IModuleGeographicService;

namespace API.Controllers.ModuleGeographicController
{
    public class DepartamentController : BaseModelController<Departament, DepartamentDTO, DepartamentRequest>
    {
        private readonly IDepartamentService _departamentService;
        private readonly IMapper _mapper;


        public DepartamentController(IBaseModelService<Departament, DepartamentDTO, DepartamentRequest> baseService,IDepartamentService departamentService, IMapper mapper) : base(baseService, mapper)
        {
            _departamentService = departamentService;
            _mapper = mapper;
        }

    }
}
