using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.EntityData.EntityDetailRequest
{
    public class DocumentDetailRequest
    {

        

        [Url(ErrorMessage = "La URL del enlace no es válida")]
        public string UrlLink { get; set; } = string.Empty;
        [Url(ErrorMessage = "La URL del PDF no es válida")]
        public string UrlPdf { get; set; } = string.Empty;

        [Url(ErrorMessage = "La URL del PDF de experiencia no es válida")]
        public string UrlPdfExperience { get; set; } = string.Empty;


    }
}

