using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Implementations.ModuleBaseRepository;
using Repository.Interfaces.IModuleOperationRepository;
using Utilities.Helper;
 



namespace Repository.Implementations.ModuleOperationRepository
{
    public class ExperienceRepository : BaseModelRepository<Experience, ExperienceDTO, ExperienceRequest>, IExperienceRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<Experience, ExperienceDTO> _helperRepository;

        public ExperienceRepository(ApplicationContext context, IMapper mapper, IHelper<Experience, ExperienceDTO> helperRepository, IConfiguration configuration) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _helperRepository = helperRepository;
            _configuration = configuration;
        }


        public async Task<Experience> AddAsync(Experience experience)
        {
            _context.Experiences.Add(experience);
            await _context.SaveChangesAsync();
            return experience;
        }


        public async Task<Experience?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Experiences

                // Datos base
                .Include(e => e.StateExperience)
                .Include(e => e.User)
                .ThenInclude(u => u.Person)

                .Include(e => e.Evaluations)
                .ThenInclude(ev => ev.EvaluationCriterias)
                .ThenInclude(ec => ec.Criteria)
                // Líder
                .Include(e => e.Leaders)

                // Institución + subtablas
                .Include(e => e.Institution)
                .ThenInclude(i => i.Departaments)
                .Include(e => e.Institution)
                .ThenInclude(i => i.Municipalitis)
                .Include(e => e.Institution)
                    .ThenInclude(i => i.Communes)
                .Include(e => e.Institution)
                    .ThenInclude(i => i.EEZones)
                .Include(e => e.Institution)
                    .ThenInclude(i => i.Addresss)

                // Documentos
                .Include(e => e.Documents)

                // Líneas temáticas
                .Include(e => e.ExperienceLineThematics)
                    .ThenInclude(x => x.LineThematic)

                // Grados
                .Include(e => e.ExperienceGrades)
                    .ThenInclude(x => x.Grade)

                // Grupo poblacional
                .Include(e => e.ExperiencePopulations)
                    .ThenInclude(x => x.PopulationGrade)

                // Desarrollo
                .Include(e => e.Developments)

                // Objetivos + soportes + monitoreos
                .Include(e => e.Objectives)
                    .ThenInclude(o => o.SupportInformations)
                .Include(e => e.Objectives)
                    .ThenInclude(o => o.Monitorings)

                .FirstOrDefaultAsync(e => e.Id == id);
        }

      
        public async Task<Experience?> GetDetailByIdAsync(int id)
        {
            return await _context.Experiences
                .Include(e => e.Institution)
                    .ThenInclude(i => i.Departaments)
                .Include(e => e.Institution)
                    .ThenInclude(i => i.Municipalitis)
                .Include(e => e.Institution)
                    .ThenInclude(i => i.Communes)
                .Include(e => e.Institution)
                    .ThenInclude(i => i.EEZones)
                .Include(e => e.Leaders)
                .Include(e => e.Documents)
                .Include(e => e.Objectives)
                    .ThenInclude(o => o.SupportInformations)
                .Include(e => e.Objectives)
                    .ThenInclude(o => o.Monitorings)
                .Include(e => e.ExperienceLineThematics)
                .Include(e => e.ExperienceGrades)
                    .ThenInclude(g => g.Grade)
                .Include(e => e.ExperiencePopulations)
                    .ThenInclude(p => p.PopulationGrade)
                .Include(e => e.Developments)
                .Include(e => e.HistoryExperiences)
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.Id == id && e.State == true);
        }





        public async Task UpdateAsync(Experience experience)
        {
            _context.Experiences.Update(experience);
            await _context.SaveChangesAsync();
        }

        public async Task PatchSaveAsync()
        {
            await _context.SaveChangesAsync();
        }



        public async Task<Experience?> GetByIdAsync(int id)
        {
            return await _context.Experiences
                .FirstOrDefaultAsync(e => e.Id == id);
        }



        public async Task<IEnumerable<Experience>> GetAllAsync()
        {
            return await _context.Experiences.ToListAsync();
        }



        public async Task<IEnumerable<Experience>> GetByUserIdAsync(int userId)
        {
            return await _context.Experiences
                .Where(e => e.UserId == userId)
                .ToListAsync();
        }


    }
}
