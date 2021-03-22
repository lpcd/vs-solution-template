using System.Reflection;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Softfluent.Template.Core.Extensions;
using Softfluent.Template.Infrastructure.Persistance;

namespace Softfluent.Template.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Add infrastructure services such as the database base access.
        /// </summary>
        /// <param name="services">Services collection.</param>
        /// <param name="configuration">Application configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseSettings = configuration.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettings>();
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                ["Server"] = databaseSettings.Server,
                UserID = databaseSettings.UserName,
                Password = databaseSettings.Password,
                InitialCatalog = databaseSettings.DatabaseName,
                ["Trusted_Connection"] = databaseSettings.TrustedConnection
            };

            services.AddDbContext<IMyDbContext, MyDbContext>(opts =>
            {
                opts.UseSqlServer(sqlConnectionStringBuilder.ToString());
            });

            // We need to register the db context again in order for the db context to be used with the Identity framework.
            services.AddDbContext<MyDbContext>(opts => opts.UseSqlServer(sqlConnectionStringBuilder.ToString()));
            services.AddInjectableServices(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}