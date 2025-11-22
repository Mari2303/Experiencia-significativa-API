using AutoMapper;
using Entity.Dtos.ModelosParametro;
using Entity.Models.ModelosParametros;
using Entity.Requests.ModulesParamer;
using Service.Interfaces.ModuleParamer;
using Service.Interfaces.IModuleBaseService;
using API.Controllers.ModuleBaseController;

namespace API.Controllers.ModuleParamer
{
    public class PopulationGradeController : BaseModelController<PopulationGrade, PopulationGradeDTO, PopulationGradeRequest>
    {
        private readonly IPopulationGradeService _populationGradeService;
        private readonly IMapper _mapper;

        public PopulationGradeController(IBaseModelService<PopulationGrade, PopulationGradeDTO, PopulationGradeRequest> baseService, IPopulationGradeService service, IMapper mapper) : base(baseService, mapper)
        {
            _populationGradeService = service;
            _mapper = mapper;
        }
    }
}
