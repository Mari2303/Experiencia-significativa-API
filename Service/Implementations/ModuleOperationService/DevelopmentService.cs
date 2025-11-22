using Entity.Dtos.ModuleOperation;
using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace Service.Implementations.ModelOperationService
{
    public class DevelopmentService : BaseModelService<Development, DevelopmentDTO, DevelopmentRequest>, IDevelopmentService
    {
        private readonly IDevelopmentRepository _verificationRepository;
        public DevelopmentService(IDevelopmentRepository verificationRepository) : base(verificationRepository)
        {
            _verificationRepository = verificationRepository;
        }
    }
}
