using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Entity.Requests.ModuleSegurity;
using Microsoft.Extensions.Configuration;
using Repository.Implementations.ModuleBaseRepository;
using Repository.Interfaces.IModuleOperationRepository;
using Utilities.Helper;
using static Repository.Implementations.ModuleOperationRepository.HistoryExperienceRepository;

namespace Repository.Implementations.ModuleOperationRepository
{
    public class HistoryExperienceRepository : BaseModelRepository<HistoryExperience, HistoryExperienceDTO, HistoryExperienceRequest>, IHistoryExperienceRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<HistoryExperience, HistoryExperienceDTO> _helperRepository;

        public HistoryExperienceRepository(ApplicationContext context, IMapper mapper, IHelper<HistoryExperience, HistoryExperienceDTO> helperRepository, IConfiguration configuration) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _helperRepository = helperRepository;
            _configuration = configuration;
        }



        public async Task<object> GetTrackingSummaryAsync(QueryFilterRequest filters)
        {
            if (filters.Role == "SUPERADMIN")
            {
                // Admin ve todo
                var sql = @"
            SELECT 
                COUNT(DISTINCT e.Id) AS TotalExperiences,
                SUM(CASE WHEN ec.TotalScore <= 45 THEN 1 ELSE 0 END) AS ExperiencesNaciente,
                SUM(CASE WHEN ec.TotalScore BETWEEN 46 AND 79 THEN 1 ELSE 0 END) AS ExperiencesCreciente,
                SUM(CASE WHEN ec.TotalScore >= 80 THEN 1 ELSE 0 END) AS ExperiencesInspiradora,
                COUNT(CASE WHEN e.CreatedAt IS NOT NULL THEN 1 END) AS TotalExperiencesRegistradas,
                COUNT(DISTINCT i.Id) AS TotalInstitutionsWithExperiences,
                (SELECT COUNT(DISTINCT u2.Id)
                 FROM [Users] u2
                 INNER JOIN UserRoles ur2 ON u2.Id = ur2.UserId
                 INNER JOIN Roles r2 ON ur2.RoleId = r2.Id
                 WHERE r2.Name = 'Profesor') AS TotalTeachersRegistered,
                COUNT(DISTINCT CASE WHEN ev.Comments IS NOT NULL AND ev.Comments <> '' THEN e.Id END) AS TotalExperiencesWithComments,
                COUNT(DISTINCT CASE WHEN i.TestsKnow = 'SI' THEN e.Id END) AS TotalExperiencesTestsKnow
            FROM Experiences e
            LEFT JOIN Evaluations ev ON ev.ExperienceId = e.Id
            LEFT JOIN (
                SELECT EvaluationId, SUM(Score) AS TotalScore
                FROM EvaluationCriterias
                GROUP BY EvaluationId
            ) ec ON ec.EvaluationId = ev.Id
            LEFT JOIN Institutions i ON e.InstitucionId = i.Id
            LEFT JOIN [Users] u ON u.Id = e.UserId
            LEFT JOIN UserRoles ur ON u.Id = ur.UserId
            LEFT JOIN Roles r ON ur.RoleId = r.Id;
        ";

                return await _context.QueryFirstOrDefaultAsync<TrackingSummaryRequest>(sql);
            }
            else if (filters.Role == "Profesor")
            {
                // Profesor solo ve dos métricas
                var sql = @"
            SELECT 
                COUNT(DISTINCT CASE WHEN e.CreatedAt IS NOT NULL THEN e.Id END) AS TotalExperiencesRegistradas,
                COUNT(DISTINCT CASE WHEN ev.Comments IS NOT NULL AND ev.Comments <> '' THEN e.Id END) AS TotalExperiencesWithComments
            FROM Experiences e
            LEFT JOIN Evaluations ev ON ev.ExperienceId = e.Id
            WHERE e.UserId = @UserId;
        ";

                return await _context.QueryFirstOrDefaultAsync<TrackingSummaryProfesorRequest>(
                    sql,
                    new { UserId = filters.UserId }
                );
            }
            else
            {
                throw new Exception("Rol no soportado.");
            }
        }

    }
}

