using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModelosParametros;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityDetailRequest;
using Entity.Requests.ModuleOperation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Implementations.ModuleBaseRepository;
using Repository.Interfaces.IModuleOperationRepository;
using Utilities.Helper;

namespace Repository.Implementations.ModuleOperationRepository
{
    public class EvaluationRepository : BaseModelRepository<Evaluation, EvaluationDTO, EvaluationRequest>, IEvaluationRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<Evaluation, EvaluationDTO> _helperRepository;
        public EvaluationRepository(ApplicationContext context, IMapper mapper, IHelper<Evaluation, EvaluationDTO> helperRepository, IConfiguration configuration) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _helperRepository = helperRepository;
            _configuration = configuration;
        }

        public async Task<Evaluation> AddEvaluationAsync(Evaluation evaluation)
        {
            _context.Evaluations.Add(evaluation);
            await _context.SaveChangesAsync();
            return evaluation;
        }

        public async Task AddEvaluationCriteriaAsync(EvaluationCriteria evalCriteria)
        {
            _context.EvaluationCriterias.Add(evalCriteria);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCriteriaAsync(Criteria criteria)
        {
            _context.Criteria.Update(criteria);
            await _context.SaveChangesAsync();
        }
        public async Task<Criteria?> GetCriteriaByIdAsync(int id)
        {
            return await _context.Criteria
                .FirstOrDefaultAsync(c => c.Id == id);
        }


     
        public async Task<Experience?> GetExperienceWithInstitutionAsync(int experienceId)
        {
            return await _context.Experiences
                .Include(e => e.Evaluations)
                .Include(e => e.Institution)
                .Include(e => e.ExperienceLineThematics)
                    .ThenInclude(elt => elt.LineThematic) 
                .FirstOrDefaultAsync(e => e.Id == experienceId);


        }



        public async Task<EvaluationDetailRequest> GetEvaluationDetailAsync(int evaluationId)
        {
            var evaluation = await _context.Evaluations
                .Include(e => e.User)
                    .ThenInclude(u => u.Person)
                .Include(e => e.EvaluationCriterias)
                    .ThenInclude(ec => ec.Criteria)
                .Include(e => e.Experience)
                    .ThenInclude(ex => ex.Institution)
                .Include(e => e.Experience)
                    .ThenInclude(ex => ex.ExperienceLineThematics)
                        .ThenInclude(elt => elt.LineThematic)
                .FirstOrDefaultAsync(e => e.Id == evaluationId);

            if (evaluation == null)
                throw new KeyNotFoundException("La evaluación no existe");

            // Mapear la entidad al request
            var request = _mapper.Map<EvaluationDetailRequest>(evaluation);

            // Asignar los datos del usuario
            request.UserName = evaluation.User?.Username ?? "Usuario desconocido";
            request.Email = evaluation.User?.Person?.Email ?? "";

            return request;
        }




        public async Task<Evaluation?> GetByExperienceAndTypeAsync(int experienceId, string typeEvaluation)
        {
            return await _context.Evaluations
                .Include(e => e.EvaluationCriterias)
                .FirstOrDefaultAsync(e =>
                    e.ExperienceId == experienceId &&
                    e.TypeEvaluation == typeEvaluation &&
                    e.State == true);
        }



        public async Task<Evaluation> UpdateEvaluationAsync(Evaluation evaluation, List<EvaluationCriteria> newCriteria)
        {
            // Actualizar los campos principales
            _context.Evaluations.Update(evaluation);

            // Eliminar criterios antiguos
            var oldCriteria = _context.EvaluationCriterias
                .Where(c => c.EvaluationId == evaluation.Id);

            _context.EvaluationCriterias.RemoveRange(oldCriteria);

            // Agregar los nuevos criterios
            foreach (var c in newCriteria)
            {
                c.EvaluationId = evaluation.Id;
                await _context.EvaluationCriterias.AddAsync(c);
            }

            await _context.SaveChangesAsync();
            return evaluation;
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }




        public async Task UpdateEvaluationPdfUrlAsync(int evaluationId, string pdfUrl)
        {
            // Buscar la evaluación existente
            var evaluation = await _context.Evaluations.FindAsync(evaluationId);

            if (evaluation == null)
                throw new Exception("Evaluation not found");

            // Actualizar SOLO el campo de URL del PDF
            evaluation.UrlEvaPdf = pdfUrl;

            // Guardar cambios
            await _context.SaveChangesAsync();
        }




        public async Task<Evaluation?> GetEvaluationByIdTrackedAsync(int evaluationId)
        {
            try
            {
                return await _context.Evaluations
                    .Include(e => e.EvaluationCriterias)
                        .ThenInclude(ec => ec.Criteria)
                    .Include(e => e.Experience)
                        .ThenInclude(ex => ex.Institution)
                    .Include(e => e.Experience)
                        .ThenInclude(ex => ex.ExperienceLineThematics)
                            .ThenInclude(elt => elt.LineThematic)
                    .FirstOrDefaultAsync(e => e.Id == evaluationId); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error al recuperar la evaluación con tracking: {ex.Message}");
                throw;
            }
        }







        public async Task<IEnumerable<Experience>> GetExperiencesWithInitialEvaluationAsync()
        {
            return await _context.Experiences
                .Include(e => e.Evaluations)
                .Where(e => e.Evaluations.Any(ev => ev.TypeEvaluation == "Inicial"))
                .ToListAsync();
        }

        public async Task<IEnumerable<Experience>> GetExperiencesWithFinalEvaluationAsync()
        {
            return await _context.Experiences
                .Include(e => e.Evaluations)
                .Where(e => e.Evaluations.Any(ev => ev.TypeEvaluation == "Final"))
                .ToListAsync();
        }

        public async Task<IEnumerable<Experience>> GetExperiencesWithoutEvaluationAsync()
        {
            return await _context.Experiences
                .Include(e => e.Evaluations)
                .Where(e => !e.Evaluations.Any()) // no tiene evaluaciones
                .ToListAsync();
        }













    }
}
