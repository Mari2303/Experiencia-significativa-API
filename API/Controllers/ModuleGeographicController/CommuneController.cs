using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleGeographic;
using Entity.Models.ModuleGeographic;
using Entity.Requests.ModuleGeographic;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.IModuleGeographicService;

namespace API.Controllers.ModuleGeographicController
{
    public class CommuneController : BaseModelController<Commune, CommuneDTO, CommuneRequest>
    {
        private readonly ICommuneService _communeService; 
        private readonly IMapper _mapper;

        public CommuneController(IBaseModelService<Commune, CommuneDTO, CommuneRequest> baseService,ICommuneService communeService, IMapper mapper) : base(baseService, mapper)
        {
            _communeService = communeService;
            _mapper = mapper;
        }




    }
}
