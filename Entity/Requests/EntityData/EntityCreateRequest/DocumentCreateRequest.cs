using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.EntityData.EntityCreateRequest
{
    public class DocumentCreateRequest
    {
        public string Name { get; set; } = string.Empty;
   
        public string UrlLink { get; set; } = string.Empty;
        public string UrlPdf { get; set; }  = string.Empty;
        public string UrlPdfExperience { get; set; }  = string.Empty;


    }
}
