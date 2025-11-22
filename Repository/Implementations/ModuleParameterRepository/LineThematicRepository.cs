using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModelosParametro;
using Entity.Models.ModelosParametros;
using Entity.Requests.ModulesParamer;
using Microsoft.Extensions.Configuration;
using Repository.Implementations.ModuleBaseRepository;
using Repository.Interfaces.ModuleParamer;
using Utilities.Helper;

namespace Repository.Implementations.ModulePararmer
{
    public class LineThematicRepository : BaseModelRepository<LineThematic, LineThematicDTO, LineThematicRequest>, ILineThematicRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<LineThematic, LineThematicDTO> _helperRepository;

        public LineThematicRepository(ApplicationContext context, IMapper mapper, IConfiguration configuration, IHelper<LineThematic, LineThematicDTO> helperRepository) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _helperRepository = helperRepository;
        }
    
    }
}
