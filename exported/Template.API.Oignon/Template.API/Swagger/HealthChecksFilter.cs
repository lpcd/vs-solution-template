using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace $safeprojectname$.Swagger
{
    /// <summary>
    /// Filter for create route in API for check if is alive.
    /// </summary>
    public class HealthChecksFilter : IDocumentFilter
    {
        private const string _healthCheckEndpoint = @"/api/healthcheck";

        /// <summary>
        /// Include heath check.
        /// </summary>
        /// <param name="swaggerDoc"><see cref="OpenApiDocument"/></param>
        /// <param name="context"><see cref="DocumentFilterContext"/></param>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var pathItem = new OpenApiPathItem();

            var operation = new OpenApiOperation();
            operation.Tags.Add(new OpenApiTag { Name = "ApiHealth" });

            pathItem.AddOperation(OperationType.Get, operation);
            swaggerDoc?.Paths.Add(_healthCheckEndpoint, pathItem);
        }
    }
}