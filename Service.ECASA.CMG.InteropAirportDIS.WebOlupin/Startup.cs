using AspNetCore.Authentication.ApiKey;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Identity.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Extensions;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Persistence.Entities;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Helpers;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Persistence.ORM.EF;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Persistence.ORM.EF.Providers;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Persistence.ORM.EF.Repositories;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Providers;
using Serilog;
using System.Linq;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

            this.configuration = configuration;
            this.env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Framework.Guama.Media.Presentation.Web.Common.Options.RelativeMediaFileManagementOptions>(configuration.GetSection("FileManagement"));

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<DbContext, ApplicationDbContext>();

            services.PerformIdentityWebCommonServiceRegistration();
            services.PerformMediaWebCommonRelativePathFileManagementServiceRegistration();


            services.AddScoped<IEntityRepository<Framework.Guama.Core.Security.Common.Persistence.Entities.Role, System.Guid>, Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Repositories.RoleRepository>();
            services.AddScoped<IEntityRepository<Framework.Guama.Core.Security.Common.Persistence.Entities.Permission, int>, Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Repositories.PermissionRepository>();
            services.AddScoped<IEntityRepository<Framework.Guama.Core.Persistence.ORM.EF.Entities.Trace, long>, Framework.Guama.Core.Persistence.ORM.EF.Repositories.TraceRepository>();
            services.AddScoped<IEntityRepository<ApiKey, System.Guid>, ApiKeyRepository>();
            services.AddScoped<IEntityRepository<Carrier, string>, CarrierRepository>();
            services.AddScoped<IEntityRepository<Category, System.Guid>, CategoryRepository>();
            services.AddScoped<IEntityRepository<Kind, InterFIDS.Persistence.Enumerations.OperationKind>, KindRepository>();
            services.AddScoped<IEntityRepository<Status, System.Guid>, StatusRepository>();
            services.AddScoped<IEntityRepository<Terminal, System.Guid>, TerminalRepository>();
            services.AddScoped<IEntityRepository<Operation, long>, OperationRepository>();
            services.AddScoped<IEntityRepository<CheckIn, int>, CheckInRepository>();

            services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Providers.DbSchemaConfigurationProvider>();
            services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, DbSchemaConfigurationProvider>();

            services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper, DataInitializationHelper>();

            services.AddHttpContextAccessor();

            services.AddSingleton<Framework.Guama.Core.Presentation.Web.Security.Providers.Facade.IRoleIdProviderFacade>(RoleMemoryProvider.Instance);

            services.AddAuthentication()
                .AddApiKeyInHeaderOrQueryParams<ApiKeySessionProvider>(ApiKeyDefaults.AuthenticationScheme, options =>
            {
                options.Realm = "VIDERHE Hotel OTT Restfull API";
                options.KeyName = API.Common.Constants.Authentication.API_KEY_HEADER_PROPERTY;
                options.SuppressWWWAuthenticateHeader = true;
            });

            //#region Globalization configuration
            //var defaultCulture = new System.Globalization.CultureInfo("es");

            services.AddLocalization();

            //services.Configure<RequestLocalizationOptions>(options =>
            //{
            //    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(defaultCulture);
            //    options.SupportedCultures = new[] { defaultCulture };
            //    options.SupportedUICultures = new[] { defaultCulture };

            //    options.RequestCultureProviders = new[] { new Framework.Guama.Core.Presentation.Web.Common.Localization.UrlRequestCultureProvider() };
            //});

            //services.AddSingleton<GlobalViewLocalizationHelper>();
            //#endregion

            services.Configure<Microsoft.AspNetCore.Routing.RouteOptions>(options => options.LowercaseUrls = true);

            services.AddResponseCaching();
            services.AddMemoryCache();
            services.AddSession();

            services.AddMvc(mvc =>
            {
                mvc.EnableEndpointRouting = false;
            }).AddJsonOptions(json =>
            {
                json.JsonSerializerOptions.Converters.Add(new Converters.LocalDateTimeConverter());
            });

            services.AddDataProtection().PersistKeysToFileSystem(new System.IO.DirectoryInfo(System.IO.Path.Combine(env.ContentRootPath, "dpkeys")));

            services.AddSingleton<Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider, Microsoft.AspNetCore.Mvc.ViewFeatures.CookieTempDataProvider>();
        }

        public void Configure(IApplicationBuilder app, Microsoft.Extensions.Options.IOptions<RequestLocalizationOptions> requestLocalizationOptions, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory, DbContext dbContext)
        {
            System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
            System.AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            loggerFactory.AddSerilog(Log.Logger);

            //app.UseRequestLocalization(requestLocalizationOptions.Value);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsStaging())
            {
                dbContext.Database.Migrate();

                var dataInitializationHelpers = app.ApplicationServices.GetServices<Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper>();

                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    var scopedDbContext = serviceScope.ServiceProvider.GetService<DbContext>();

                    foreach (var dataInitializationHelper in dataInitializationHelpers)
                    {
                        dataInitializationHelper.InitialiseData(scopedDbContext);
                    }
                }

                if (!(dbContext as ApplicationDbContext).ApiKeys.Any())
                {
                    dbContext.Set<ApiKey>().Add(new ApiKey
                    {
                        Token = configuration["Defaults:TempRootApiKeyToken"],
                        Enabled = true,
                        HasFullAccess = true,
                        Name = "Acceso Total Temporal",
                        ExpirateAt = System.DateTime.Now.AddDays(3)
                    });

                    (dbContext as Framework.Guama.Core.Persistence.ORM.EF.Context.Contract.AbstractTraceableDbContext).SaveChanges("system");
                }
            }
            else
            {
                app.UseExceptionHandler("/error/exception");

                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/error/{0}");

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute("defaultAreaRoutes",
                    template: "{area:exists}/{controller=home}/{action=index}/{id?}");

                routes.MapRoute(
                    name: "defaultRoutes",
                    template: "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
