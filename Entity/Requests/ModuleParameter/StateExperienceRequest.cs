using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleBase;

namespace Entity.Requests.ModulesParamer
{
    public class StateExperienceRequest : BaseRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

       
    }
}
