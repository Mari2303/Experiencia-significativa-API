using System;

using Entity.Dtos.ModuleOperation;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Repository.Interfaces.IModuleBaseRepository;

namespace Repository.Interfaces.IModuleOperationRepository
{
    public interface ISupportInformationRepository : IBaseModelRepository<SupportInformation, SupportInformationDTO, SupportInformationRequest>
    {
    }
}
