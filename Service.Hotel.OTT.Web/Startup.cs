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
using MOROPO.VIDERHE.Service.Hotel.OTT.Persistence.Entities;
using MOROPO.VIDERHE.Service.Hotel.OTT.Web.Persistence.ORM.EF.Repositories;
using Serilog;
using System.Linq;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web
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

            services.AddDbContext<Persistence.ORM.EF.ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<DbContext, Persistence.ORM.EF.ApplicationDbContext>();

            services.PerformIdentityWebCommonServiceRegistration();
            services.PerformMediaWebCommonRelativePathFileManagementServiceRegistration();
            
            
            services.AddScoped<IEntityRepository<Framework.Guama.Core.Security.Common.Persistence.Entities.Permission, int>, Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Repositories.PermissionRepository>();
            services.AddScoped<IEntityRepository<Framework.Guama.Core.Persistence.ORM.EF.Entities.Trace, long>, Framework.Guama.Core.Persistence.ORM.EF.Repositories.TraceRepository>();
            services.AddScoped<IEntityRepository<CustomService, System.Guid>, CustmoServiceRepository>();

            services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Providers.DbSchemaConfigurationProvider>();
            services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.DbSchemaConfigurationProvider>();

            services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper, Helpers.DataInitializationHelper>();

            services.AddHttpContextAccessor();

            services.AddAuthentication()
                .AddApiKeyInHeaderOrQueryParams<Providers.ApiKeySessionProvider>(ApiKeyDefaults.AuthenticationScheme, options =>
            {
                options.Realm = "VIDERHE Hotel OTT Restfull API";
                options.KeyName = API.Common.Constants.Authorization.API_KEY_HEADER_PROPERTY;
                options.SuppressWWWAuthenticateHeader = true;
            });

            #region Globalization configuration
            var defaultCulture = new System.Globalization.CultureInfo("es");

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(defaultCulture);
                options.SupportedCultures = new[] { defaultCulture };
                options.SupportedUICultures = new[] { defaultCulture };

                options.RequestCultureProviders = new[] { new Framework.Guama.Core.Presentation.Web.Common.Localization.UrlRequestCultureProvider() };
            });

            services.AddSingleton<Helpers.GlobalViewLocalizationHelper>();
            #endregion

            services.Configure<Microsoft.AspNetCore.Routing.RouteOptions>(options => options.LowercaseUrls = true);

            services.AddResponseCaching();
            services.AddMemoryCache();
            services.AddSession();

            services.AddMvc(mvc =>
            {
                mvc.EnableEndpointRouting = false;
            });

            services.AddDataProtection().PersistKeysToFileSystem(new System.IO.DirectoryInfo(System.IO.Path.Combine(env.ContentRootPath, "dpkeys")));

            services.AddSingleton<Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider, Microsoft.AspNetCore.Mvc.ViewFeatures.CookieTempDataProvider>();

            #region Swagger
            var openApiSecurityScheme = new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
            {
                Description = string.Format("Authorization Header \"{0}: {1}\"", API.Common.Constants.Authorization.API_KEY_HEADER_PROPERTY, "{token}"),
                Name = "Authorization",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
            };

            services.AddSingleton(openApiSecurityScheme);

            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "VIDERHE Hotel OTT Restfull API",
                    Version = "v1"
                });
                setup.DocInclusionPredicate((string stringParam, Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription apiDescription) =>
                {
                    return apiDescription.RelativePath.StartsWith("api/");
                });
                setup.AddSecurityDefinition(API.Common.Constants.Authorization.API_KEY_HEADER_PROPERTY, openApiSecurityScheme);
                setup.OperationFilter<Filters.Swagger.OperationSwaggerFilter>();
                setup.EnableAnnotations();
                setup.IgnoreObsoleteActions();
            });
            #endregion
        }

        public void Configure(IApplicationBuilder app, Microsoft.Extensions.Options.IOptions<RequestLocalizationOptions> requestLocalizationOptions, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory, DbContext dbContext)
        {
            System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
            System.AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            loggerFactory.AddSerilog(Log.Logger);

            app.UseRequestLocalization(requestLocalizationOptions.Value);

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

                if (!(dbContext as Persistence.ORM.EF.ApplicationDbContext).ApiKeys.Any())
                {
                    var entity = new ApiKey
                    {
                        Token = configuration["Defaults:TempRootApiKeyToken"],
                        Enabled = true,
                        Name = "Acceso Total Temporal",
                        ExpirateAt = System.DateTime.Now.AddDays(3)
                    };

                    entity.PermissionBridges = dbContext.Set<Framework.Guama.Core.Security.Common.Persistence.Entities.Permission>().Select(item => new ApiKeyPermissionBridge { SternId = item.Id, Stern = item, Prow = entity }).ToList();

                    dbContext.Set<ApiKey>().Add(entity);

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

            app.UseSwagger(setup =>
            {
                setup.RouteTemplate = "api/docs/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(setup =>
            {
                setup.SwaggerEndpoint("/api/docs/v1/swagger.json", "VIDERHE Hotel OTT Restfull API v1");
                setup.RoutePrefix = "api/docs";
            });

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
