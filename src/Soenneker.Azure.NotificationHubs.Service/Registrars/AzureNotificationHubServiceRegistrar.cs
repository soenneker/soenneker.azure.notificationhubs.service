using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Azure.NotificationHubs.Service.Abstract;

namespace Soenneker.Azure.NotificationHubs.Service.Registrars;

/// <summary>
/// A .NET client generated from the Slack OpenAPI schema, updated daily
/// </summary>
public static class AzureNotificationHubServiceRegistrar
{
    /// <summary>
    /// Adds <see cref="IAzureNotificationHubService"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddAzureNotificationHubServiceAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IAzureNotificationHubService, AzureNotificationHubService>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IAzureNotificationHubService"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddAzureNotificationHubServiceAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IAzureNotificationHubService, AzureNotificationHubService>();

        return services;
    }
}
