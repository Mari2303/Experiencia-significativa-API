using Entity.Requests.ModuleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.ModuleParameter
{
    public class CriteriaRequest : BaseRequest
    {
       
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;



    }
}
