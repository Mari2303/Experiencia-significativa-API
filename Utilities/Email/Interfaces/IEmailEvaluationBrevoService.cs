using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Email.Interfaces
{
    public interface IEmailEvaluationBrevoService
    {
        Task SendEvaluationResultEmailAsync(string toEmail, string userName, string evaluationResult);
    }
}
