using Soenneker.Copper.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Copper.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class CopperOpenApiHttpClientTests : HostedUnitTest
{
    private readonly ICopperOpenApiHttpClient _httpclient;

    public CopperOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<ICopperOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
