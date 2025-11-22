using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.IModuleSegurityService;

namespace API.Controllers.ModuleSegurityController
{
    public class PersonController : BaseModelController<Person, PersonDTO, PersonRequest>
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(IBaseModelService<Person, PersonDTO, PersonRequest> baseService, IPersonService service, IMapper mapper)
            : base(baseService, mapper)
        {
            _personService = service;
            _mapper = mapper;
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UserRegisterRequest request)
        {
            try
            {
                var result = await _personService.CreatePersonAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}








    