using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.ModuleGeographic;
using Entity.Models.ModuleGeographic;
using Entity.Requests.ModuleGeographic;
using Repository.Interfaces.IModuleGeographicRepository;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.IModuleGeographicService;

namespace Service.Implementations.ModuleGeographicService
{
    public class DepartamentService : BaseModelService<Departament, DepartamentDTO, DepartamentRequest>, IDepartamentService
    {

        private readonly IDepartamentRepository _departamentRepository;

        public DepartamentService(IDepartamentRepository departamentRepository) : base(departamentRepository)
        {
            _departamentRepository = departamentRepository;
        }
    }
}
