using Entity.Requests.ModuleBase;

namespace Entity.Requests.ModuleSegurity
{
    public class ModuleRequest : BaseRequest
    {
        
        public string Name { get; set; } = string.Empty;

       
        public string Description { get; set; } = string.Empty;
    }
}
