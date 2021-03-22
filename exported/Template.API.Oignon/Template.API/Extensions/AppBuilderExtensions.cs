using Microsoft.AspNetCore.Builder;

namespace $safeprojectname$.Extensions
{
    /// <summary>
    /// Adds extensions to the <see cref="IApplicationBuilder"/>
    /// </summary>
    public static class AppBuilderExtensions
    {
        /// <summary>
        /// Configure Swagger UI.
        /// </summary>
        /// <param name="app">Application builder</param>
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });
        }
    }
}