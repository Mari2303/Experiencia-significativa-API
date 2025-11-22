using API.Controllers.ModuleBaseController;
using AutoMapper;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityCreateRequest;
using Entity.Requests.EntityData.EntityUpdateRequest;
using Entity.Requests.ModuleOperation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Implementations.ModelOperationService;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace API.Controllers.ModuleOperationController
{
    public class EvaluationController : BaseModelController<Evaluation, EvaluationDTO, EvaluationRequest>
    {
        private readonly IEvaluationService _evaluationService;
        private readonly IMapper _mapper;
        public EvaluationController(IBaseModelService<Evaluation, EvaluationDTO, EvaluationRequest> baseService, IEvaluationService evaluationService, IMapper mapper) : base(baseService, mapper)
        {
            _evaluationService = evaluationService;
            _mapper = mapper;
        }

        //  Crear una nueva evaluación
        [Authorize(Roles = "SUPERADMIN")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] EvaluationCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _evaluationService.CreateEvaluationAsync(request);
            return Ok(result);
        }

        //  Actualizar una evaluación existente
        [Authorize(Roles = "SUPERADMIN")]
        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] EvaluationUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _evaluationService.UpdateEvaluationAsync(id, request);
            return Ok(result);
        }



        // Regenerar PDF manualmente (opcional)
        [Authorize(Roles = "SUPERADMIN")]
        [HttpPost("{id:int}/generate-pdf")]
        public async Task<IActionResult> GeneratePdf(int id)
        {
            var result = await _evaluationService.GenerateAndAttachPdfAsync(id);
            return Ok(result);
        }


        [Authorize]
        [HttpGet("filter/inicial")]
        public async Task<IActionResult> FilterInitial()
        {
            var result = await _evaluationService.FilterInitialEvaluationAsync();
            return Ok(result);
        }

        [Authorize]
        [HttpGet("filter/final")]
        public async Task<IActionResult> FilterFinal()
        {
            var result = await _evaluationService.FilterFinalEvaluationAsync();
            return Ok(result);
        }

        [Authorize]
        [HttpGet("filter/sin-evaluacion")]
        public async Task<IActionResult> FilterWithoutEvaluation()
        {
            var result = await _evaluationService.FilterWithoutEvaluationAsync();
            return Ok(result);
        }


    }

    }

