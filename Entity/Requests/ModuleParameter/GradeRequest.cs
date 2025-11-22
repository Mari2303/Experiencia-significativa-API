using Entity.Requests.ModuleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.ModulesParamer
{
    public class GradeRequest : BaseRequest
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
