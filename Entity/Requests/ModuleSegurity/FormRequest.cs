using Entity.Requests.ModuleBase;

namespace Entity.Requests.ModuleSegurity
{
  
    public class FormRequest : BaseRequest
    {
       
        public string Name { get; set; } = string.Empty;

     
        public string Path { get; set; } = string.Empty;

       
        public string Description { get; set; } = string.Empty;

    
        public string Icon { get; set; } = string.Empty;

      
        public int Order { get; set; }
    }
}
