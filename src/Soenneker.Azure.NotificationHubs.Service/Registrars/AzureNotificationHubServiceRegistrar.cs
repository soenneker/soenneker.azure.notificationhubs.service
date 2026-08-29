using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Azure.NotificationHubs.Service.Abstract;

namespace Soenneker.Azure.NotificationHubs.Service.Registrars;

/// <summary>
/// An async thread-safe singleton for the Azure Notification Hubs client
/// </summary>
public static class AzureNotificationHubServiceRegistrar
{
    /// <summary>
    /// Adds <see cref="IAzureNotificationHubService"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddAzureNotificationHubServiceAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IAzureNotificationHubService, AzureNotificationHubService>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IAzureNotificationHubService"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddAzureNotificationHubServiceAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IAzureNotificationHubService, AzureNotificationHubService>();

        return services;
    }
}
