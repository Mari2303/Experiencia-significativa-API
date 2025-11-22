using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace Service.Implementations.ModelOperationService
{
    public class InstitutionService : BaseModelService<Institution, InstitutionDTO, InstitutionRequest>, IInstitutionService
    {
        private readonly IInstitutionRepository _institutionRepository;
        public InstitutionService(IInstitutionRepository institutionRepository) : base(institutionRepository)
        {
            _institutionRepository = institutionRepository;
        }
    }
}
