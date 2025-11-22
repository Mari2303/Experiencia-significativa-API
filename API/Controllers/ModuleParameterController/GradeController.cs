using AutoMapper;
using Entity.Dtos.ModelosParametro;
using Entity.Models.ModelosParametros;
using Entity.Requests.ModulesParamer;
using Service.Interfaces.ModuleParamer;
using Service.Interfaces.IModuleBaseService;
using API.Controllers.ModuleBaseController;

namespace API.Controllers.ModuleParamer
{
    public class GradeController : BaseModelController<Grade, GradeDTO, GradeRequest>
    {
        private readonly IGradeService _gradeService;
        private readonly IMapper _mapper;

        public GradeController(IBaseModelService<Grade, GradeDTO, GradeRequest> baseService, IGradeService service, IMapper mapper) : base(baseService, mapper)
        {
            _gradeService = service;
            _mapper = mapper;
            
        }

    }
}
