using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MOROPO.VIDERHE.Service.Weather.WebOlupin.Options;
using MOROPO.VIDERHE.Service.Weather.WebOlupin.Providers;

namespace MOROPO.VIDERHE.Service.Weather.WebOlupin
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<OpenWeatherMapOptions>(configuration.GetSection("OpenWeatherMap"));
            services.Configure<NetworkProxyOptions>(configuration.GetSection("NetworkProxy"));

            services.AddSingleton<OpenWeatherMapCacheProvider>();

            services.AddMvc(mvc =>
            {
                mvc.EnableEndpointRouting = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
