using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.ModuleBase;
using Entity.Models.ModuleGeographic;

namespace Entity.Models.ModuleOperation
{
    public class Institution : GenericModel
    {
        public string Address { get; set; } = string.Empty;
        public uint Phone { get; set; }
        public string CodeDane { get; set; } = string.Empty;
        public string EmailInstitucional { get; set; } = string.Empty;
        public string NameRector { get; set; } = string.Empty;
        public string Caracteristic { get; set; } = string.Empty;
        public string TerritorialEntity { get; set; } = string.Empty;
        public string TestsKnow { get; set; } = string.Empty;
        public ICollection<Experience> Experiences { get; set; } = new List<Experience>();
        public ICollection<Address> Addresss { get; set; } = new List<Address>();
        public ICollection<EEZone> EEZones { get; set; } = new List<EEZone>();
        public ICollection<Departament> Departaments { get; set;} = new List<Departament>();
        public ICollection<Municipality> Municipalitis { get; set; } = new List<Municipality>();
        public ICollection<Commune> Communes { get; set; } = new List<Commune>();
    }
}
