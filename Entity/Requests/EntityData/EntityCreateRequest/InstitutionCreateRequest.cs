using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Requests.EntityData.EntityDataRequest;
using Entity.Requests.ModuleGeographic;

namespace Entity.Requests.EntityData.EntityCreateRequest
{
    public class InstitutionCreateRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public uint Phone { get; set; }
        public string CodeDane { get; set; } = string.Empty;
        public string EmailInstitucional { get; set; } = string.Empty;
        public string NameRector { get; set; } = string.Empty;
        public string Caracteristic { get; set; } = string.Empty;
        public string TerritorialEntity { get; set; } = string.Empty;
        public string TestsKnow { get; set; } = string.Empty;


        public IEnumerable<AddressInfoRequest> Addresses { get; set; } = new List<AddressInfoRequest>();
        public IEnumerable<CommuneInfoRequest> Communes { get; set; } = new List<CommuneInfoRequest>();
        public IEnumerable<DepartamentInfoRequest> Departamentes { get; set; } = new List<DepartamentInfoRequest>();
        public IEnumerable<EEZoneInfoRequest> EEZones { get; set; } = new List<EEZoneInfoRequest>();
        public IEnumerable<MunicipalityInfoRequest> Municipalities { get; set; } = new List<MunicipalityInfoRequest>();
    }
}
