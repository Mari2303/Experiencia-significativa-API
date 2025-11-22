using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Requests.EntityData.EntityCreateRequest
{
    public class GradeCreateRequest
    {
        public int GradeId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
