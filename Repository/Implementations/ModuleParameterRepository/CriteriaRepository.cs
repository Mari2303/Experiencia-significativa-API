using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Context;
using Entity.Dtos;
using Entity.Dtos.ModelosParametro;
using Entity.Models;
using Entity.Models.ModelosParametros;
using Entity.Requests;
using Entity.Requests.ModuleParameter;
using Microsoft.Extensions.Configuration;
using Repository.Implementations.ModuleBaseRepository;
using Repository.Interfaces;
using Repository.Interfaces.ModuleParamer;
using Utilities.Helper;

namespace Repository.Implementations.ModulePararmer
{
    public  class CriteriaRepository : BaseModelRepository<Criteria, CriteriaDTO, CriteriaRequest>, ICriteriaRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<Criteria, CriteriaDTO> _helperRepository;

        public CriteriaRepository(ApplicationContext context, IMapper mapper, IConfiguration configuration, IHelper<Criteria, CriteriaDTO> helperRepository) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _helperRepository = helperRepository;
        }
    }
    
}
