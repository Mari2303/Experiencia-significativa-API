using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.ModuleBase;
using Entity.Models.ModuleOperation;

namespace Entity.Models.ModuleGeographic
{
    public class EEZone : GenericModel
    {
        public int InstitutionId { get; set; }
        public virtual Institution Institution { get; set; } = null!;
    }
}
