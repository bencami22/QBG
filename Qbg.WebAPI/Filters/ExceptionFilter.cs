using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Configuration;
using Qbg.IServices;

namespace Qbg.WebAPI.Filters
{

    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly IMailUtility _mailUtility;

        public CustomExceptionFilterAttribute(IHostingEnvironment hostingEnvironment, IConfiguration configuration, IMailUtility mailUtility)
        {
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
            _mailUtility = mailUtility;
        }

        public override void OnException(ExceptionContext context)
        {
            _mailUtility.SendMail($"{_hostingEnvironment.EnvironmentName} - Exception Occurred",
                context.Exception.Message,
                _configuration["MailSettings:ExceptionMail:From"],
                _configuration.GetSection("MailSettings:ExceptionMail:To").Get<string[]>().ToList<string>());
            
            Console.WriteLine(context.Exception);
        }

    }
}
