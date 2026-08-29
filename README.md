[![](https://img.shields.io/nuget/v/soenneker.azure.notificationhubs.service.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.azure.notificationhubs.service/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.azure.notificationhubs.service/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.azure.notificationhubs.service/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.azure.notificationhubs.service.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.azure.notificationhubs.service/)

# Soenneker.Azure.NotificationHubs.Service

An async thread-safe singleton for the Azure Notification Hubs client.

## Install

```bash
dotnet add package Soenneker.Azure.NotificationHubs.Service
```

## Quick start

```csharp
using Soenneker.Azure.NotificationHubs.Service.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddAzureNotificationHubServiceAsSingleton();
```

Adds `IAzureNotificationHubService` as a singleton service.

## What you get

- `IAzureNotificationHubService` — An async thread-safe singleton for the Azure Notification Hubs client.
- `AzureNotificationHubServiceRegistrar` — An async thread-safe singleton for the Azure Notification Hubs client.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IAzureNotificationHubService.Get(cancellationToken)` | Gets the Azure Notification Hubs client. | A task containing the client. |
| `AzureNotificationHubServiceRegistrar.AddAzureNotificationHubServiceAsSingleton(services)` | Adds `IAzureNotificationHubService` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `AzureNotificationHubServiceRegistrar.AddAzureNotificationHubServiceAsScoped(services)` | Adds `IAzureNotificationHubService` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
