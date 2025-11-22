using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace Service.Implementations.ModelOperationService
{
    public class ExperienceGradeService : BaseModelService<ExperienceGrade, ExperienceGradeDTO, ExperienceGradeRequest>, IExperienceGradeService
    {
        private readonly IExperienceGradeRepository experienceGradeRepository;
        public ExperienceGradeService(IExperienceGradeRepository experienceGradeRepository) : base(experienceGradeRepository)
        {
            this.experienceGradeRepository = experienceGradeRepository;
        }
    }
}
