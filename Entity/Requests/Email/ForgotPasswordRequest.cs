using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.Email
{
    public class ForgotPasswordRequest
    {
        public string Email { get; set; } = string.Empty;
    }
}
