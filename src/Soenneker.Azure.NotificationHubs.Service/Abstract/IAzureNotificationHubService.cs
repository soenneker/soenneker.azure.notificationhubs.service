using Microsoft.Azure.NotificationHubs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Azure.NotificationHubs.Service.Abstract;

/// <summary>
/// An async thread-safe singleton for the Azure Notification Hubs client
/// </summary>
public interface IAzureNotificationHubService : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the Azure Notification Hubs client.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the client.</returns>
    ValueTask<NotificationHubClient> Get(CancellationToken cancellationToken = default);
}
