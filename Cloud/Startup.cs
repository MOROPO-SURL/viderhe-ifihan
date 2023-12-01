using MediaToolkit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Security.Common.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Identity.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.Framework.Guama.Security.Essential.Persistence.ORM.EF.Extensions;
using MOROPO.Framework.Guama.Security.Essential.Presentation.Web.Backend.Extensions;
using MOROPO.VIDERHE.Cloud.Hubs;
using MOROPO.VIDERHE.Cloud.Managers;
using MOROPO.VIDERHE.Cloud.Options;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Persistence.ORM.EF.Providers;
using Serilog;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            #region Ensure Required Assemblies load

            _ = new Extend.Essential.Descriptors.EssentialExtensionDescriptor();
            _ = new Extend.Essential.Overlaying.Descriptors.SimpleHighlightsOverlayDescriptor();
            _ = new Extend.Essential.Transitioning.Transitions.ArriveTransitionDescriptor();
            _ = new Extend.Essential.Templating.Descriptors.SimplePictureTemplateDescriptor();

            var extensionRootDirectoryPath = configuration["Viderhe:ExtensionRootDirectoryPath"];

            var extensionRootDirectoryInfo = new System.IO.DirectoryInfo(extensionRootDirectoryPath);

            var extensionCustomRuntimeLibraries = Microsoft.Extensions.DependencyModel.DependencyContext.Default.RuntimeLibraries.Where(l => l.Type == "project" && l.Name.Contains(".Viderhe.Extend.") && !l.Name.Contains(".Viderhe.Support.Extend") && !l.Name.Contains(".Viderhe.Extend.Common")).ToList();

            if (extensionRootDirectoryInfo.Exists)
            {
                var extensionDirectoryInfos = extensionRootDirectoryInfo.GetDirectories();

                foreach (var extensionDirectoryInfo in extensionDirectoryInfos)
                {
                    var extensionLibraryFileInfos = Providers.ViderheExtensionLibraryFileInfosProvider.GetRelevantToCloud(extensionDirectoryInfo);

                    foreach (var extensionLibraryFileInfo in extensionLibraryFileInfos)
                    {
                        var assembly = System.Reflection.Assembly.LoadFrom(extensionLibraryFileInfo.FullName);

                        var assemblyName = assembly.GetName();

                        extensionCustomRuntimeLibraries.Add(new Microsoft.Extensions.DependencyModel.RuntimeLibrary(
                            "project",
                            assemblyName.Name,
                            assemblyName.Version.ToString(),
                            null,
                            new Microsoft.Extensions.DependencyModel.RuntimeAssetGroup[] { },
                            new Microsoft.Extensions.DependencyModel.RuntimeAssetGroup[] { },
                            Enumerable.Empty<Microsoft.Extensions.DependencyModel.ResourceAssembly>(),
                            Enumerable.Empty<Microsoft.Extensions.DependencyModel.Dependency>(),
                            false));
                    }
                }
            }

            foreach (var runtimeLibrary in extensionCustomRuntimeLibraries)
            {
                System.AppDomain.CurrentDomain.Load(runtimeLibrary.Name);
            }

            #endregion

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

            this.configuration = configuration;
            this.env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MediaThumbnailResizeOptions>(configuration.GetSection("MediaThumbnailResize"));
            services.Configure<MediaPathOptions>(configuration.GetSection("MediaPath"));
            services.Configure<JwtOptions>(configuration.GetSection("JWT"));
            //services.Configure<FfmpegOptions>(configuration.GetSection("FFmpeg"));

            services.AddDbContext<Persistence.ORM.EF.ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<DbContext, Persistence.ORM.EF.ApplicationDbContext>();

            services.PerformCoreWebSecurityCommonFrontendServiceRegistration();
            services.PerformSecurityEssentialWebBackendServiceRegistration();
            services.PerformIdentityWebCommonServiceRegistration();

            services.AddScoped<IEntityRepository<Account, System.Guid>, Persistence.ORM.EF.Repositories.AccountRepository>();
            services.AddScoped<IEntityRepository<Frame, long>, Persistence.ORM.EF.Repositories.FrameRepository>();
            services.AddScoped<IEntityRepository<Placard, System.Guid>, Persistence.ORM.EF.Repositories.PlacardRepository>();
            services.AddScoped<IEntityRepository<Player, string>, Persistence.ORM.EF.Repositories.PlayerRepository>();
            services.AddScoped<IEntityRepository<Screenplay, System.Guid>, Persistence.ORM.EF.Repositories.ScreenplayRepository>();
            services.AddScoped<IEntityRepository<Moderator, System.Guid>, Persistence.ORM.EF.Repositories.ModeratorRepository>();
            services.AddScoped<IEntityRepository<Extension, System.Guid>, Persistence.ORM.EF.Repositories.ExtensionRespository>();
            services.AddScoped<IEntityRepository<Template, System.Guid>, Persistence.ORM.EF.Repositories.TemplateRepository>();
            services.AddScoped<IEntityRepository<ScheduledRelaunch, System.Guid>, Persistence.ORM.EF.Repositories.ScheduledRelaunchRepository>();
            services.AddScoped<IEntityRepository<Sound, System.Guid>, Persistence.ORM.EF.Repositories.SoundRepository>();
            services.AddScoped<IEntityRepository<Gradient, System.Guid>, Persistence.ORM.EF.Repositories.GradientRepository>();
            services.AddScoped<IEntityRepository<Text, System.Guid>, Persistence.ORM.EF.Repositories.TextRepository>();
            services.AddScoped<IEntityRepository<Tag, System.Guid>, Persistence.ORM.EF.Repositories.TagRepository>();

            services.AddSingleton<IImageFileManagerFacade, ImageFileManager>();
            services.AddSingleton<IThumbnailFileManagerFacade, ThumbnailFileManager>();
            services.AddSingleton<IVideoFileManagerFacade, VideoFileManager>();
            services.AddSingleton<SoundFileManager>();

            services.AddMediaToolkit(configuration["FFmpeg:MainBinaryPath"]);

            services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, BusinessDbSchemaConfigurationProvider>();

            services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper, Helpers.BusinessDataInitializationHelper>();

            services.AddScoped<Microsoft.AspNetCore.Authorization.IAuthorizationHandler, Security.Authorization.Requirement.Handler.AccountModerationRequirementHandler>();

            services.AddAuthentication(config =>
            {
                config.DefaultScheme = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(config =>
            {
                config.AccessDeniedPath = new PathString("/error/403");
                config.LoginPath = new PathString("/security/account/login");
                config.ExpireTimeSpan = System.TimeSpan.FromMinutes(5);
                config.SlidingExpiration = true;
            })
            .AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Issuer"],
                    ValidateLifetime = false,
                    RequireExpirationTime = false,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
                    ClockSkew = System.TimeSpan.Zero
                };
                config.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];
                        // If the request is for our hub...
                        var path = context.HttpContext.Request.Path;

                        if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs/dashboard"))
                        {
                            // Read the token out of the query string
                            context.Token = accessToken;
                        }

                        return System.Threading.Tasks.Task.CompletedTask;
                    }
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, policy =>
                {
                    policy.AddAuthenticationSchemes(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireClaim(System.Security.Claims.ClaimTypes.NameIdentifier);
                });
                options.AddPolicy(Security.Authorization.Policies.ACCOUNT_VALIDATED_MODERATION, policy =>
                {
                    policy.AddAuthenticationSchemes(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme);
                    policy.AddRequirements(new Security.Authorization.Requirement.AccountModerationRequirement());
                });
            });

            #region SAPRESSC.Core.Security concreter dependencies configuration
            services.AddSingleton<Framework.Guama.Core.Presentation.Web.Security.Helpers.Facade.ILicenseValidationHelperFacade, Security.Licensing.WilcardLicenseValidator>();

            services.AddTransient<Framework.Guama.Core.Presentation.Web.Security.Models.View.Contrat.IUserProfileViewModel, Models.View.UserProfileViewModel>();

            services.AddSingleton<Framework.Guama.Core.Presentation.Web.Common.ModelBinding.Contract.IConcretModelBindHelper, Helpers.Binding.ConcretModelBindHelper>();

            services.AddScoped<Framework.Guama.Core.Presentation.Web.Security.Providers.Facade.IIdentityProviderFacade, IdentityManager>();
            services.AddScoped<Framework.Guama.Core.Presentation.Web.Security.Managers.Facade.IUserProfileManagerFacade, UserProfileManager>();
            #endregion

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

            services.AddSingleton<Helpers.Localization.GlobalViewLocalizationHelper>();
            #endregion

            services.Configure<Microsoft.AspNetCore.Routing.RouteOptions>(options => options.LowercaseUrls = true);

            services.AddResponseCaching();
            services.AddMemoryCache();
            services.AddSession();

            services.AddSignalR(options =>
            {
                options.MaximumParallelInvocationsPerClient = 1;
            });

            services.AddMvc(mvc =>
            {
                mvc.EnableEndpointRouting = false;
                mvc.ModelBinderProviders.Insert(0, new Framework.Guama.Core.Presentation.Web.Common.ModelBinding.AbstractsModelBinderProvider());
            })
            .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization(options =>
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                {
                    return factory.Create(typeof(SharedResources));
                }
            );

            services.AddDataProtection()
                .PersistKeysToFileSystem(new System.IO.DirectoryInfo(System.IO.Path.Combine(env.ContentRootPath, "dpkeys")));

            services.AddSingleton<Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider, Microsoft.AspNetCore.Mvc.ViewFeatures.CookieTempDataProvider>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Microsoft.Extensions.Options.IOptions<RequestLocalizationOptions> requestLocalizationOptions, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory, DbContext dbContext)
        {
            //FFMediaToolkit.FFmpegLoader.FFmpegPath = ffmpegOptions.Value.BinariesPath;

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

                if (!(dbContext as Persistence.ORM.EF.ApplicationDbContext).Users.Any())
                {
                    var defaultUserId = configuration["DefaultUser:Id"];

                    var k3y = new System.Guid(0x6abae711, 0xcd91, 0x47e7, 0xad, 0x8a, 0xae, 0x88, 0xe4, 0x50, 0x25, 0x4d);

                    var protectedPassword = (dbContext as Persistence.ORM.EF.ApplicationDbContext).CreateSecureUser(k3y, defaultUserId, "system");

                    Log.Logger.Information(string.Format(">>>>>> Protected Password : \"{0}\" => \"{1}\"", defaultUserId, protectedPassword));
                }
            }
            else
            {
                app.UseExceptionHandler("/error");

                app.UseHsts();
            }

            var contentTypePovider = new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider();

            contentTypePovider.Mappings.Add(".apk", "application/vnd.android.package-archive");

            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = contentTypePovider
            });

            app.UseAuthentication();
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<DashboardHub>("/hubs/dashboard");
                endpoints.MapHub<PlayerHub>("/hubs/player");
            });

            //app.UseMvcWithDefaultRoute();

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
