using Entity.Requests.ModuleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.ModulesParamer
{
    public class PopulationGradeRequest : BaseRequest
    {

        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;



    }
}
