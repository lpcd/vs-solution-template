using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using $safeprojectname$.Swagger;
using $ext_safeprojectname$.Core.Mappers;

namespace $safeprojectname$.Extensions
{
    /// <summary>
    /// Defines extensions for the <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add swagger doc generation to the <see cref="IServiceCollection"/> instance.
        /// </summary>
        /// <param name="services">Service collection</param>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API",
                    Version = "v1",
                    Description = "API documention"
                });

                options.DocumentFilter<HealthChecksFilter>();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Adds and load auto mapper profiles.
        /// </summary>
        /// <param name="services">Service collection</param>
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TodoProfile());
            });

            services.AddSingleton(mappingConfig.CreateMapper());
        }
    }
}