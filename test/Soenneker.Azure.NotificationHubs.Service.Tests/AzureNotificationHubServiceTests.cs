using Soenneker.Azure.NotificationHubs.Service.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Azure.NotificationHubs.Service.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class AzureNotificationHubServiceTests : HostedUnitTest
{
    private readonly IAzureNotificationHubService _util;

    public AzureNotificationHubServiceTests(Host host) : base(host)
    {
        _util = Resolve<IAzureNotificationHubService>(true);
    }

    [Test]
    public void Default()
    {

    }
}
