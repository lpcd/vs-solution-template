using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using $safeprojectname$.Configurations;
using $safeprojectname$.Extensions;
using $ext_safeprojectname$.Core.Extensions;
using $ext_safeprojectname$.Infrastructure.Extensions;
using $ext_safeprojectname$.Infrastructure.Persistance;

namespace $safeprojectname$
{
    /// <summary>
    /// Configure all requirement for API.
    /// </summary>
    public class Startup
    {
        private const string _healthCheckEndpoint = @"/api/healthcheck";

        /// <summary>
        /// Gets the API configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Gets or sets api configuration
        /// </summary>
        public ApiConfiguration ApiConfiguration { get; set; }

        /// <summary>
        /// Creates the API bootstraper instance.
        /// </summary>
        /// <param name="configuration">API configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            ApiConfiguration = Configuration.Get<ApiConfiguration>();
        }

        /// <summary>
        /// Configures the API services.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });

            services.AddOptions();
            services.AddMemoryCache();
            services.AddInfrastructure(Configuration);
            services.AddBusinessServices();
            services.AddInjectableServices(Assembly.GetExecutingAssembly());

            services.AddHealthChecks();
            services.AddControllers();

            if (ApiConfiguration.EnableSwagger)
            {
                services.AddSwagger();
            }
        }

        /// <summary>
        /// Configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application builder</param>
        /// <param name="env">Web host environment</param>
        /// <param name="dbContext">DbContext for lunch migration when API start</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MyDbContext dbContext)
        {
            dbContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (ApiConfiguration.EnableSwagger)
            {
                app.ConfigureSwagger();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks(_healthCheckEndpoint);
            });
        }
    }
}