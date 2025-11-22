using Entity.Requests.ModuleBase;

namespace Entity.Requests.ModuleSegurity
{
    public class RoleRequest : BaseRequest
    {
       
        public string Code { get; set; } = string.Empty;
       
        public string Name { get; set; } = string.Empty;
      
        public string Description { get; set; } = string.Empty;
    }
}
