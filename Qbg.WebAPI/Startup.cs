using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql.Data.EntityFrameworkCore.Extensions;
using Qbg.Data;
using Qbg.Data.Settings;
using Qbg.IRepos;
using Qbg.IServices;
using Qbg.MySqlEfRepos;
using Qbg.Services;
using Qbg.WebAPI.Filters;

namespace WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = configBuilder.Build();

            var check = Configuration["MailSettings:Server"];
            HostingEnvironment = hostingEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .AddJsonOptions(jsonOptions => jsonOptions.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            services.AddDbContext<ApplicationContext>(options =>
                options.UseMySQL(this.Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Qbg.Data")
            ));


            Configuration.GetSection("MailSettings").Get<MailSettings>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IQueueRepository, QueueRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IQueueService, QueueService>();
            services.AddSingleton<ISecurityService, SecurityService>();
            services.AddSingleton<IMailUtility, SmtpClientUtility>();
            services.AddSingleton(typeof(MailSettings));

        }


            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
