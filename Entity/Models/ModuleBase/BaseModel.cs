namespace Entity.Models.ModuleBase
{
 
    public class BaseModel
    {
     
        public int Id { get; set; }
      
        public bool State { get; set; }
      
        public DateTime CreatedAt { get; set; }

     
        public DateTime? DeletedAt { get; set; }
    }
}
