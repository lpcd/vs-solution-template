using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace $safeprojectname$.Extensions
{
    /// <summary>
    /// Provides extensions for the <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds business services.
        /// </summary>
        /// <param name="services">Services collection.</param>
        /// <returns></returns>
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddInjectableServices(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

        /// <summary>
        /// Register injectable services from a given assembly into the service collection.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <param name="assembly">Assembly.</param>
        /// <returns><see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddInjectableServices(this IServiceCollection services, Assembly assembly)
        {
            IEnumerable<Type> injectableServiceTypes = assembly.GetTypes().Where(x => x.GetCustomAttribute<InjectableAttribute>() != null);

            foreach (var serviceType in injectableServiceTypes)
            {
                InjectableAttribute serviceAttribute = serviceType.GetCustomAttribute<InjectableAttribute>();
                Type[] serviceInterfaces = serviceType.GetInterfaces();

                foreach (Type serviceInterface in serviceInterfaces)
                {
                    RegisterService(services, serviceInterface, serviceType, serviceAttribute.LifeTime);
                }
            }

            return services;
        }

        /// <summary>
        /// Registers a service in the service collection.
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="serviceInterface">Service interface</param>
        /// <param name="serviceType">Service implementation type</param>
        /// <param name="lifeTime">Service life time</param>
        private static void RegisterService(IServiceCollection services, Type serviceInterface, Type serviceType, ServiceLifetime lifeTime)
        {
            Func<Type, Type, IServiceCollection> addServiceMethod = lifeTime switch
            {
                ServiceLifetime.Transient => services.AddTransient,
                ServiceLifetime.Scoped => services.AddScoped,
                ServiceLifetime.Singleton => services.AddSingleton,
                _ => services.AddTransient
            };

            addServiceMethod?.Invoke(serviceInterface, serviceType);
        }
    }
}