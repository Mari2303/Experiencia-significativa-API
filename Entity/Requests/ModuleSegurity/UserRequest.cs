using Entity.Requests.ModuleBase;
using System.ComponentModel.DataAnnotations;

namespace Entity.Requests.ModuleSegurity
{
    public class UserRequest : BaseRequest
    {
       
        public string Code { get; set; } = string.Empty;
     
     
        public string Username { get; set; } = string.Empty;

      
        public string Password { get; set; } = string.Empty;
       
        public int PersonId { get; set; }
    
        public string? Person { get; set; } = null!;
        public bool State { get; set; }

     

    }
}
