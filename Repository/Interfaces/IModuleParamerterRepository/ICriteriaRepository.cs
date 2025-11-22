using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.ModelosParametro;
using Entity.Models.ModelosParametros;
using Entity.Requests.ModuleParameter;
using Repository.Interfaces.IModuleBaseRepository;

namespace Repository.Interfaces.ModuleParamer
{
    public interface ICriteriaRepository : IBaseModelRepository<Criteria, CriteriaDTO, CriteriaRequest>
    { }
}
