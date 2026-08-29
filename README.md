[![](https://img.shields.io/nuget/v/soenneker.azure.notificationhubs.service.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.azure.notificationhubs.service/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.azure.notificationhubs.service/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.azure.notificationhubs.service/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.azure.notificationhubs.service.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.azure.notificationhubs.service/)

# Soenneker.Azure.NotificationHubs.Service

Creates and caches an Azure SDK `NotificationHubClient` from application configuration.

## Installation

```bash
dotnet add package Soenneker.Azure.NotificationHubs.Service
```

## Configuration

```json
{
  "Azure": {
    "NotificationHubs": {
      "ConnectionString": "Endpoint=sb://...",
      "HubName": "notifications",
      "EnableTestSend": false
    }
  }
}
```

`ConnectionString` and `HubName` are required. `EnableTestSend` is optional; when omitted, the Azure SDK's default client behavior is used.

Keep the connection string in a secret provider or environment variables such as `Azure__NotificationHubs__ConnectionString`. Choose a listen-only, send-only, or full-access policy according to what the consuming service actually does.

## Registration and use

```csharp
using Microsoft.Azure.NotificationHubs;
using Soenneker.Azure.NotificationHubs.Service.Abstract;
using Soenneker.Azure.NotificationHubs.Service.Registrars;

builder.Services.AddAzureNotificationHubServiceAsSingleton();

public sealed class HubClientConsumer(IAzureNotificationHubService hubService)
{
    public async ValueTask<NotificationHubClient> GetClient(
        CancellationToken cancellationToken) =>
        await hubService.Get(cancellationToken);
}
```

## Lifecycle

- The client is created on the first `Get()` call and reused afterward.
- Concurrent initialization shares the same cached operation.
- Configuration changes do not rebuild an initialized client; dispose and replace the service to use a new hub or rotated connection string.
- Missing required configuration fails initialization.
- Let DI dispose the service. A scoped registration creates one cached client per scope; the singleton registration creates one for the application.

Most applications should use `Soenneker.Azure.NotificationHubs.Installations` or `Soenneker.Azure.NotificationHubs.Senders`, which register this service automatically and expose task-focused APIs.
