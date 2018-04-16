using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Qbg.Data.Settings;
using Qbg.IServices;

namespace Qbg.Services
{
    public class SmtpClientUtility : IMailUtility
    {
        public IConfiguration Configuration;
        public SmtpClientUtility(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public async Task<bool> SendMail(string subject, string htmlBody, string from, List<string> to, List<string> cc = null, List<string> bcc = null)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.IsBodyHtml = true;
                mailMessage.From = new MailAddress(from);
                mailMessage.Body = htmlBody;
                mailMessage.Subject = subject;

                if (to?.Count > 0)
                {
                    foreach (string address in to)
                    {
                        mailMessage.To.Add(new MailAddress(address));
                    }
                }
                if (bcc?.Count > 0)
                {
                    foreach (string address in bcc)
                    {
                        mailMessage.Bcc.Add(new MailAddress(address));
                    }
                }
                if (cc?.Count > 0)
                {
                    foreach (string address in cc)
                    {
                        mailMessage.CC.Add(new MailAddress(address));
                    }
                }

                using (SmtpClient client = new SmtpClient(Configuration["MailSettings:Server"], Convert.ToInt32(Configuration["MailSettings:Port"])))
                {
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(Configuration["MailSettings:Username"], Configuration["MailSettings:Password"]);

                    try
                    {
                        await client.SendMailAsync(mailMessage);
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
