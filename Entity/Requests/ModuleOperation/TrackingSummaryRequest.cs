using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.ModuleOperation
{
    public class TrackingSummaryRequest
    {
        public int TotalExperiences { get; set; }
        public int ExperiencesNaciente { get; set; }
        public int ExperiencesCreciente { get; set; }
        public int ExperiencesInspiradora { get; set; }

        public int TotalExperiencesRegistradas { get; set; }
        public int TotalExperiencesCreadas { get; set; }

        public int TotalInstitutionsWithExperiences { get; set; }
        public int TotalTeachersRegistered { get; set; }

        public int TotalExperiencesWithComments { get; set; }
        public int TotalExperiencesTestsKnow { get; set; }
    }
}
