using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace Service.Implementations.ModelOperationService
{
    public class ExperiencePopulationService : BaseModelService<ExperiencePopulation, ExperiencePopulationDTO, ExperiencePopulationRequest>, IExperiencePopulationService
    {
        private readonly IExperiencePopulationRepository _experiencePopulationRepository;
        public ExperiencePopulationService(IExperiencePopulationRepository experiencePopulationRepository) : base(experiencePopulationRepository)
        {
            _experiencePopulationRepository = experiencePopulationRepository;
        }
    }
}
