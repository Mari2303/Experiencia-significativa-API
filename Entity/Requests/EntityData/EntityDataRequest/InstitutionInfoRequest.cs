using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Requests.ModuleGeographic;
using Microsoft.Identity.Client;

namespace Entity.Requests.EntityData.EntityDataRequest
{
    public class InstitutionInfoRequest
    {
        
        [Required(ErrorMessage = "El nombre de la institución es obligatorio")]
        [StringLength(150, ErrorMessage = "El nombre de la institución no debe superar los 150 caracteres")]
        public string Name { get; set; } = string.Empty;



        [Required(ErrorMessage = "El código DANE es obligatorio")]
        [StringLength(12, ErrorMessage = "El código DANE debe ser numérico y tener entre 5 y 10 dígitos")]
        public string CodeDane { get; set; } = string.Empty;

      
        public IEnumerable<DepartamentInfoRequest> Departamentes { get; set; } = new List<DepartamentInfoRequest>();
        public IEnumerable<MunicipalityInfoRequest> Municipalities { get; set; } = new List<MunicipalityInfoRequest>();

    }
}
