using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.ModelOperationService;


namespace Service.Implementations.ModelOperationService
{
    public class HistoryExperienceService : BaseModelService<HistoryExperience, HistoryExperienceDTO, HistoryExperienceRequest>, IHistoryExperienceService
    {
        private readonly IHistoryExperienceRepository _historyExperienceRepository;
        public HistoryExperienceService(IHistoryExperienceRepository historyExperienceRepository) : base(historyExperienceRepository)
        {
            _historyExperienceRepository = historyExperienceRepository;
        }


        public async Task<object> GetTrackingSummaryAsync(QueryFilterRequest filters)
        {
            try
            {
                return await _historyExperienceRepository.GetTrackingSummaryAsync(filters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error en {nameof(GetTrackingSummaryAsync)}: {ex.Message}");
                throw;
            }
        }



    }
}
