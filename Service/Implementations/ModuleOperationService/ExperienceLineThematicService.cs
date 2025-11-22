using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace Service.Implementations.ModelOperationService
{
    public class ExperienceLineThematicService : BaseModelService<ExperienceLineThematic, ExperienceLineThematicDTO, ExperienceLineThematicRequest>, IExperienceLineThematicService
    {
        private readonly IExperienceLineThematicRepository _experienceLineThematicRepository;
        public ExperienceLineThematicService(IExperienceLineThematicRepository experienceLineThematicRepository) : base(experienceLineThematicRepository)
        {
            _experienceLineThematicRepository = experienceLineThematicRepository;
        }
    }
}
