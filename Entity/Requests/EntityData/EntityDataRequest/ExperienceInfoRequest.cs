using Entity.Requests.EntityData.EntityDetailRequest;
using Entity.Requests.EntityData.EntityUpdateRequest;
using Entity.Requests.ModuleOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Requests.EntityData.EntityUpdateRequest;
using Entity.Requests.ModuleOperation;

namespace Entity.Requests.EntityData.EntityDataRequest
{
    public  class ExperienceInfoRequest
    {
        public string NameExperiences { get; set; } = string.Empty;
        public string Developmenttime { get; set; }
        public int StateExperienceId { get; set; }
        public string EvaluationResult { get; set; }

        public string UrlPdf { get; set; } = string.Empty;
        public List<LeaderDetailRequest> Leaders { get; set; }
       
    }
}
