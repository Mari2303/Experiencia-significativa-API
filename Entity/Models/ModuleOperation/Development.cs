

using Entity.Models.ModuleBase;

namespace Entity.Models.ModuleOperation
{
    public class Development : BaseModel
    {
        public string CrossCuttingProject { get; set; } = string.Empty;  //Seleccione  la o las Técnicas en articulación con el SENA vinculadas
        public string Population { get; set; } = string.Empty;  //Indique el modelo educativo en el que se enmarca  el desarrollo de la  Experiencia Significativa
        public string PedagogicalStrategies { get; set; } = string.Empty; // Seleccione de quien o quines a  recibió apoyo para la formulación, fundamentación y/o desarrollo
        public string Coverage {  get; set; } = string.Empty;  // La Experiencia Significativa se encuentra vinculada en el Proyecto Educativo Institucional
        public string CovidPandemic {  get; set; } = string.Empty; // 
        public int ExperienceId { get; set; }
        public virtual Experience Experience { get; set; } = null!;

    }
}
