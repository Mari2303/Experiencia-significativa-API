using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Email.Interfaces
{
    public interface IBrevoEmailService
    {
        Task<bool> SendEmailAsync(string to, int templateId, Dictionary<string, object>? parameters = null);
    
    }
}
