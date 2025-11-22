using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos;
using Entity.Dtos.ModelosParametro;
using Entity.Models;
using Entity.Models.ModelosParametros;
using Entity.Requests;
using Entity.Requests.ModuleParameter;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.ModuleParamer;

namespace API.Controllers.ModuleParamer
{
    public class CriteriaController : BaseModelController<Criteria, CriteriaDTO, CriteriaRequest>
    {
        private readonly ICriteriaService _criteriaService;
        private readonly IMapper _mapper;

        public CriteriaController(IBaseModelService<Criteria, CriteriaDTO, CriteriaRequest> baseService, ICriteriaService service, IMapper mapper) : base(baseService, mapper)
        {
            _criteriaService = service;
            _mapper = mapper;
        }
    
    }
}
