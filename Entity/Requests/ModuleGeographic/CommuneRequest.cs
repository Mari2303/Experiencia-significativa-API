using Entity.Requests.ModuleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.ModuleGeographic
{
    public class CommuneRequest : BaseRequest
    {
        public string Name { get; set; } = string.Empty;

    }
}