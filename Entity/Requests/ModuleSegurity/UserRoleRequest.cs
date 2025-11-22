using Entity.Requests.ModuleBase;

namespace Entity.Requests.ModuleSegurity
{
    public class UserRoleRequest : BaseRequest
    {
       
        public int UserId { get; set; }
       
        public int RoleId { get; set; }
       
        public string? User { get; set; } = null!;
      
        public string? Role { get; set; } = null!;
    }
}
