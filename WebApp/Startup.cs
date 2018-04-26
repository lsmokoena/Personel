using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Extensions;
using Serilog.Filters;
using System.IO;
using Personel.Models;
using Dream.Extensions;
using DAL.Models;
using DAL.Repository;
using DAL.Interface;
using DAL.Data;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Dream
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        public IHostingEnvironment _env { get; }
        //public Serilog.ILogger _logger { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Enable portable dev database

            string conn = Configuration.GetConnectionString("DSM_DB");

            if (conn.Contains("%CONTENTROOTPATH%"))
            {
                conn = conn.Replace("%CONTENTROOTPATH%", _env.ContentRootPath);
            }

            services.AddSingleton<ApplicationSettings>(new ApplicationSettings(conn));
            services.AddDbContext<PersonelContext>(options => options.UseSqlServer(conn));

            /*using (var connection = new System.Data.SqlClient.SqlConnection(conn))
            {
                connection.Open(); // <-- this should fail if the login doesn't work
                connection.Close();
            }*/

            services.AddScoped <IUserRepository, UserRepository>();
            services.AddScoped <IAccountTypeRepository, AccountTypeRepository>();
            services.AddScoped <IBankRepository, BankRepository>();
            services.AddScoped <ISupportRepository, SupportRepository>();

            services.AddScoped <IAddressRepository, AddressRepository>();
            services.AddScoped <IBankAccountRepository, BankAccountRepository> ();
            services.AddScoped <ICategoryRepository, CategoryRepository> ();
            services.AddScoped <ICountryRepository, CountryRepository> ();

            services.AddScoped <ILocationRepository, LocationRepository> ();
            services.AddScoped <IMessageTypeRepository, MessageTypeRepository> ();
            services.AddScoped <INotificationRepository, NotificationRepository> ();
            services.AddScoped<INotificationContentRepository, NotificationContentRepository>();

            services.AddScoped <INotificationTypeRepository, NotificationTypeRepository> ();
            services.AddScoped <IPersonRepository, PersonRepository> ();
            services.AddScoped <IPersonRepository, PersonRepository> ();
            services.AddScoped <IRequestRepository, RequestRepository> ();

            services.AddScoped <IReviewRepository, ReviewRepository> ();
            services.AddScoped <ISkillRepository, SkillRepository> ();

            services.AddSingleton(Configuration);

            // Add CookieTempDataProvider after AddMvc and include ViewFeatures.
            // using Microsoft.AspNetCore.Mvc.ViewFeatures;
            // this effectively enables us to make use of TempData[] which is nice for toasts
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();

            // this is in package Microsoft.AspNetCore.NodeServices 
            services.AddNodeServices();

            //Adding logging
            services.AddSingleton<Serilog.ILogger>(x =>
            {
                string connectionString = Configuration.GetConnectionString("DSM_DB");
                return new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.LiterateConsole()
                        .WriteTo.RollingFile(Path.Combine(_env.ContentRootPath, @"Logs/DSM_WebApp-{Date}.log"))
                        .WriteTo.MSSqlServer(connectionString, "Logs", Serilog.Events.LogEventLevel.Verbose, autoCreateSqlTable: true)
                        .CreateLogger();
            });

            // Add framework services.
            services.AddMvc();
            services.AddOptions();

            var AppSettingOptions = Configuration.GetSection(nameof(AppSettings));

            //Set global app configuration
            services.Configure<AppSettings>(config =>
            {
                config.application_full_name = AppSettingOptions[nameof(AppSettings.application_full_name)];
                config.application_short_name = AppSettingOptions[nameof(AppSettings.application_short_name)];
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();

            //setup cookie auth
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "auth",
                LoginPath = new PathString("/Account/Login/"),
                AccessDeniedPath = new PathString("/Account/Forbidden/"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(
                    builder =>
                    {
                        builder.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                            var error = context.Features.Get<IExceptionHandlerFeature>();
                            if (error != null)
                            {
                                context.Response.AddApplicationError(error.Error.Message);
                                await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                            }
                        });
                    });
            }

            app.UseStaticFiles();
            app.UseStatusCodePagesWithReExecute("/Error/{0}");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=User}/{action=Index}/{id?}");
            });

            //Populate database with test data
            DSM_DbInitializer.Initialize(app.ApplicationServices);
        }

    }
}
