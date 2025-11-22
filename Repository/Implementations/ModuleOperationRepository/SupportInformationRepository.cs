using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModuleOperation;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleOperation;
using Microsoft.Extensions.Configuration;
using Repository.Implementations.ModuleBaseRepository;
using Repository.Interfaces.IModuleOperationRepository;
using Utilities.Helper;

namespace Repository.Implementations.ModuleOperationRepository
{
    public class SupportInformationRepository : BaseModelRepository<SupportInformation, SupportInformationDTO, SupportInformationRequest>, ISupportInformationRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<SupportInformation, SupportInformationDTO> _helperRepository;

        public SupportInformationRepository(ApplicationContext context, IMapper mapper, IHelper<SupportInformation, SupportInformationDTO> helperRepository, IConfiguration configuration) : base(context, mapper, configuration ,helperRepository)
        {

            _context = context;
            _mapper = mapper;
            _helperRepository = helperRepository;
            _configuration = configuration;

        }
    }
}
