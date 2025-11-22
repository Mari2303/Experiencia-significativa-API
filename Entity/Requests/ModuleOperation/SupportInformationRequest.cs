using Entity.Requests.ModuleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.ModuleOperation
{
    public class SupportInformationRequest : BaseRequest
    {
        public string Summary { get; set; } = string.Empty;
        public string MetaphoricalPhrase { get; set; } = string.Empty;
        public string Testimony { get; set; } = string.Empty;
        public string FollowEvaluation { get; set; } = string.Empty;
      
    }
}
