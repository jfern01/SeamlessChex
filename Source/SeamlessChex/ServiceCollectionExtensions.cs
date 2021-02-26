namespace SeamlessChex
{
    using System;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Extension methods for IServiceCollection.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add an instance of SeamlessChexClient to the service collection.
        /// </summary>
        /// <param name="services">IServiceCollection instance.</param>
        /// <param name="apiKey">SeamlessChex API key.</param>
        /// <param name="live">SeamlessChex API live mode.</param>
        /// <param name="serviceLifetime">ServiceLifetime enum.</param>
        /// <returns>Service collection.</returns>
        public static IServiceCollection AddSeamlessChex(this IServiceCollection services, string apiKey, bool live = true, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            SeamlessChexClient Factory(IServiceProvider provider) => new SeamlessChexClient(apiKey, live);

            return serviceLifetime switch
            {
                ServiceLifetime.Singleton => services.AddSingleton(Factory),
                ServiceLifetime.Transient => services.AddTransient(Factory),
                ServiceLifetime.Scoped => services.AddScoped(Factory),
                _ => services.AddScoped(Factory),
            };
        }
    }
}
