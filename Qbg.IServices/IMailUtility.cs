using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Qbg.Data.Settings;

namespace Qbg.IServices
{
    public interface IMailUtility
    {
        Task<bool> SendMail(string subject, string htmlBody, string from, List<string> to, List<string> cc = null, List<string> bcc = null);
    }
}
