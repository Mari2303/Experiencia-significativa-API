using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.ModuleBase;
using Entity.Models.ModuleOperation;

namespace Entity.Models.ModelosParametros
{
    public class PopulationGrade : GenericModel
    {
      

        public virtual ICollection<ExperiencePopulation> ExperiencePopulations { get; set; } = new List<ExperiencePopulation>();
    }
}
