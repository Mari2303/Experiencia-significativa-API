using Entity.Requests.EntityData.EntityDataRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.EntityData.EntityUpdateRequest
{
    public class InstitutionUpdateRequest
    {
        public string? Name { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public uint? Phone { get; set; }
        public string? CodeDane { get; set; } = string.Empty;
        public string? EmailInstitucional { get; set; } = string.Empty;
        public string? NameRector { get; set; } = string.Empty;
        public string? Caracteristic { get; set; } = string.Empty;
        public string? TerritorialEntity { get; set; } = string.Empty;
        public string? TestsKnow { get; set; } = string.Empty;

        public List<AddressInfoRequest> AddressInfoRequests { get; set; } 
        public List<CommuneInfoRequest> Communes { get; set; }
        public List<DepartamentInfoRequest> Departaments { get; set; }
        public  List<EEZoneInfoRequest> EEZones { get; set; }
        public  List<MunicipalityInfoRequest> Municipalities { get; set; }
        public object Departamentes { get; set; }
    }
}
