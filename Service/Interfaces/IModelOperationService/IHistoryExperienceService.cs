
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Entity.Requests.ModuleSegurity;
using Service.Interfaces.IModuleBaseService;

namespace Service.Interfaces.ModelOperationService
{
    public interface IHistoryExperienceService : IBaseModelService<HistoryExperience, HistoryExperienceDTO, HistoryExperienceRequest>
    {

        Task<object> GetTrackingSummaryAsync(QueryFilterRequest filters);



    }
}
