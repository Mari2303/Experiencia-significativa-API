using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.ModelosParametro;
using Entity.Models.ModelosParametros;
using Entity.Requests.ModulesParamer;
using Repository.Interfaces.ModuleParamer;
using Service.Implementations.ModuleBaseService;
using Service.Implementations.ModuleSegurityService;
using Service.Interfaces.ModuleParamer;

namespace Service.Implementations.ModuleParamer
{
    public class LineThematicService : BaseModelService<LineThematic, LineThematicDTO, LineThematicRequest>, ILineThematicService
    {
        private readonly ILineThematicRepository _lineThematicRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleService"/> class.
        /// </summary>
        /// <param name="roleRepository">The repository for managing role data.</param>
        public LineThematicService(ILineThematicRepository lineThematicRepository) : base(lineThematicRepository)
        {
            _lineThematicRepository = lineThematicRepository;
        }
    
    }
}
