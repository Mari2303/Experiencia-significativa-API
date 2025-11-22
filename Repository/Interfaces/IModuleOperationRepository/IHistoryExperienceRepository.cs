using System.Data;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces.IModuleBaseRepository;

namespace Repository.Interfaces.IModuleOperationRepository
{
    public interface IHistoryExperienceRepository : IBaseModelRepository<HistoryExperience, HistoryExperienceDTO, HistoryExperienceRequest>
    {
        Task<object> GetTrackingSummaryAsync(QueryFilterRequest filters);
    }
}
