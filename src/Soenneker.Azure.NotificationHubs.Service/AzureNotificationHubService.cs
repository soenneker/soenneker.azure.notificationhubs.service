using Microsoft.Azure.NotificationHubs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.Azure.NotificationHubs.Service.Abstract;
using Soenneker.Extensions.Configuration;
using Soenneker.Utils.AsyncSingleton;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Azure.NotificationHubs.Service;

/// <inheritdoc cref="IAzureNotificationHubService"/>
public sealed class AzureNotificationHubService : IAzureNotificationHubService
{
    private readonly AsyncSingleton<NotificationHubClient> _client;
    private readonly ILogger<AzureNotificationHubService> _logger;
    private readonly IConfiguration _configuration;

    public AzureNotificationHubService(ILogger<AzureNotificationHubService> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _client = new AsyncSingleton<NotificationHubClient>(CreateClient);
    }

    private NotificationHubClient CreateClient()
    {
        var connectionString = _configuration.GetValueStrict<string>("Azure:NotificationHubs:ConnectionString");
        var hubName = _configuration.GetValueStrict<string>("Azure:NotificationHubs:HubName");
        var enableTestSend = _configuration.GetValue<bool?>("Azure:NotificationHubs:EnableTestSend");

        _logger.LogDebug("Creating Azure Notification Hubs client ({hubName})...", hubName);

        return enableTestSend.HasValue
            ? NotificationHubClient.CreateClientFromConnectionString(connectionString, hubName, enableTestSend.Value)
            : NotificationHubClient.CreateClientFromConnectionString(connectionString, hubName);
    }

    public ValueTask<NotificationHubClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    /// <summary>
    /// Releases resources used by the current instance.
    /// </summary>
    public void Dispose()
    {
        _client.Dispose();
    }

    /// <summary>
    /// Asynchronously releases resources used by the current instance.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
