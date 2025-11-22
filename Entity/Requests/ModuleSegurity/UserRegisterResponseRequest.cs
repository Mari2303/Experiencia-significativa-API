using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.ModuleSegurity
{
    public class UserRegisterResponseRequest
    {
        public int PersonId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
    }
}
