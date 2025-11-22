
using Entity.Dtos.ModuleOperation;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityCreateRequest;
using Entity.Requests.EntityData.EntityDetailRequest;
using Entity.Requests.EntityData.EntityUpdateRequest;
using Entity.Requests.ModuleOperation;
using Service.Interfaces.IModuleBaseService;

namespace Service.Interfaces.ModelOperationService
{
    public interface IExperienceService : IBaseModelService<Experience, ExperienceDTO,ExperienceRequest>
    {

        Task<bool> PatchAsync(ExperienceUpdateRequest Request);
        Task<ExperienceDetailRequest?> GetDetailByIdAsync(int id);
        Task<Experience> RegisterExperienceAsync(ExperienceCreateRequest Request);
        Task<string> GeneratePdfAndUploadAsync(int experienceId);
        Task<IEnumerable<Experience>> GetExperiencesAsync(string role, int userId);

        Task RequestEditAsync(int experienceId, int userId);
        Task ApproveEditAsync(int experienceId);

        Task<List<ExperienceEditPermissionDTO>> GetAllAsync();

        Task<Experience?> GetDetailAsync(int id);
    }
}
