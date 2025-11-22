using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.ModuleOperation;
using Entity.Requests.ModuleBase;

namespace Entity.Requests.ModuleOperation
{
    public class DevelopmentRequest : BaseRequest
    {

        public string CrossCuttingProject { get; set; } = string.Empty;
        public string Population { get; set; } = string.Empty;
        public string PedagogicalStrategies { get; set; } = string.Empty;
        public string Coverage { get; set; } = string.Empty;
        public string CovidPandemic { get; set; } = string.Empty;
      
    }
}
