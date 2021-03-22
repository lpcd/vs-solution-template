using System;
using Microsoft.Extensions.DependencyInjection;

namespace Softfluent.Template.Core.Extensions
{
    /// <summary>
    /// Tags a class that it can be injected into controllers or other services.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class InjectableAttribute : Attribute
    {
        /// <summary>
        /// Gets the life time of the injected service.
        /// </summary>
        public ServiceLifetime LifeTime { get; }

        /// <summary>
        /// Creates a new <see cref="InjectableAttribute"/> instance.
        /// </summary>
        /// <param name="lifeTime">Defines the injected service life time</param>
        public InjectableAttribute(ServiceLifetime lifeTime = ServiceLifetime.Transient)
        {
            LifeTime = lifeTime;
        }
    }
}