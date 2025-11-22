using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.ModuleOperation;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.ModelOperationService;

namespace Service.Implementations.ModelOperationService
{
    public class SupportInformationService : BaseModelService<SupportInformation, SupportInformationDTO, SupportInformationRequest>, ISupportInformationService
    {

        private readonly ISupportInformationRepository _supportInformationRepository;

        public SupportInformationService(ISupportInformationRepository supportInformationRepository) : base(supportInformationRepository)
        {
            {
                _supportInformationRepository = supportInformationRepository;
            }
        }
    }
}
