using Entity.Models.ModuleBase;

namespace Entity.Models.ModuleSegurity
{
    public class Person : BaseModel
    {
       
        public int DocumentType { get; set; }

     
        public string IdentificationNumber { get; set; } = string.Empty;

      
        public string FirstName { get; set; } = string.Empty;

   
        public string? MiddleName { get; set; } = string.Empty;

      
        public string FirstLastName { get; set; } = string.Empty;

     
        public string? SecondLastName { get; set; } = string.Empty;

     
        public string Email { get; set; } = string.Empty;

        public string CodeDane { get; set; } = string.Empty;     

        public string EmailInstitutional { get; set; } = string.Empty;

      
        public uint Phone { get; set; } 

      
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}