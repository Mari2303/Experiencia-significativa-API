using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.ModuleSegurity
{
    public class ConfirmEmailRequest
    {
        public string Email { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
    }
}
