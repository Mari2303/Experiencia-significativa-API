using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModuleSegurity;
using Entity.Models;
using Entity.Requests.ModuleSegurity;
using Microsoft.Extensions.Configuration;
using Repository.Implementations.ModuleBaseRepository;
using Repository.Interfaces.IModuleSegurityRepository;
using Utilities.Helper;

namespace Repository.Implementations.ModuleSegurityRepository
{
  
    public class FormRepository : BaseModelRepository<Form, FormDTO, FormRequest>, IFormRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<Form, FormDTO> _helperRepository;

        public FormRepository(ApplicationContext context, IMapper mapper, IConfiguration configuration, IHelper<Form, FormDTO> helperRepository) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _helperRepository = helperRepository;
        }
    }
}
