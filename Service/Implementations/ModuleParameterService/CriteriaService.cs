using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos;
using Entity.Dtos.ModelosParametro;
using Entity.Models;
using Entity.Models.ModelosParametros;
using Entity.Requests;
using Entity.Requests.ModuleParameter;
using Repository.Interfaces;
using Repository.Interfaces.ModuleParamer;
using Service.Implementations.ModuleBaseService;
using Service.Implementations.ModuleSegurityService;
using Service.Interfaces;
using Service.Interfaces.ModuleParamer;

namespace Service.Implementations.ModuleParamer
{
    public class CriteriaService : BaseModelService<Criteria, CriteriaDTO, CriteriaRequest>, ICriteriaService
    {
        private readonly ICriteriaRepository _criteriaRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleService"/> class.
        /// </summary>
        /// <param name="roleRepository">The repository for managing role data.</param>
        public CriteriaService(ICriteriaRepository criteriaRepository) : base(criteriaRepository)
        {
            _criteriaRepository = criteriaRepository;
        }
    }
    
}
