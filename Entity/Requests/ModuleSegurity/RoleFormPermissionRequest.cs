using Entity.Requests.ModuleBase;

namespace Entity.Requests.ModuleSegurity
{
    public class RoleFormPermissionRequest : BaseRequest
    {
       
        public int RoleId { get; set; }
       
        public int FormId { get; set; }
       
        public int PermissionId { get; set; }
       
        public string? Role { get; set; } = null!;
        
        public string? Form { get; set; } = null!;
       
        public string? Permission { get; set; } = null!;
    }
}
