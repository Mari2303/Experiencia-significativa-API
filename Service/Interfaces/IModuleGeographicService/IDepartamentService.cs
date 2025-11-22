using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.ModuleGeographic;
using Entity.Models.ModuleGeographic;
using Entity.Requests.ModuleGeographic;
using Service.Interfaces.IModuleBaseService;

namespace Service.Interfaces.IModuleGeographicService
{
    public interface IDepartamentService : IBaseModelService<Departament, DepartamentDTO, DepartamentRequest>
    {
    }
}
