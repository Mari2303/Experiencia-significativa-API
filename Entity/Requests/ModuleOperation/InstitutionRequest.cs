using Entity.Requests.ModuleBase;
using Entity.Requests.ModuleGeographic;

namespace Entity.Requests.ModuleOperation
{
    public class InstitutionRequest : BaseRequest
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


        public IEnumerable<AddressRequest> Addresses { get; set; } = new List<AddressRequest>();
        public IEnumerable<CommuneRequest> Communes { get; set; } = new List<CommuneRequest>();
        public IEnumerable<DepartamentRequest> Departamentes { get; set; } = new List<DepartamentRequest>();
        public IEnumerable<EEZoneRequest> EEZones { get; set; }  = new List<EEZoneRequest>();
        public IEnumerable<MunicipalityRequest> Municipalities { get; set; } = new List<MunicipalityRequest>();

    }
}
