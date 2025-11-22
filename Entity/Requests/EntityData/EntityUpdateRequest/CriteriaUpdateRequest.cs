using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.EntityData.EntityUpdateRequest
{
    public class CriteriaUpdateRequest
    {
        public int Id { get; set; }
        public string EvaluationValue { get; set; } = string.Empty;

    }
}
