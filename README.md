[![](https://img.shields.io/nuget/v/soenneker.copper.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.copper.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.copper.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.copper.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.copper.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.copper.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.copper.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.copper.httpclients/actions/workflows/codeql.yml)

# Soenneker.Copper.HttpClients

Provides a cached `HttpClient` configured for Copper's Developer API and API-key authentication headers.

## Install

```bash
dotnet add package Soenneker.Copper.HttpClients
```

## Configuration

```json
{
  "Copper": {
    "ApiKey": "your-api-key",
    "Email": "token-owner@example.com"
  }
}
```

Copper requires `X-PW-AccessToken`, `X-PW-Application`, and `X-PW-UserEmail` on API-key requests. This package sets all three.

Optional settings:

| Key | Default | Purpose |
| --- | --- | --- |
| `Copper:ClientBaseUrl` | `https://api.copper.com/developer_api/v1/` | Replaces the API base address; a trailing slash is normalized automatically |
| `Copper:Application` | `developer_api` | Sets `X-PW-Application` |
| `Copper:AuthHeaderName` | `X-PW-AccessToken` | Replaces the token header name |
| `Copper:AuthHeaderValueTemplate` | `{token}` | Formats `Copper:ApiKey`; `{token}` is replaced with the key |

## Registration

```csharp
using Soenneker.Copper.HttpClients.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddCopperOpenApiHttpClientAsSingleton();
```

Use `AddCopperOpenApiHttpClientAsScoped()` when each dependency-injection scope should own a separate cached client entry.

## Usage

```csharp
using Soenneker.Copper.HttpClients.Abstract;

public sealed class CopperAccountClient(ICopperOpenApiHttpClient clientProvider)
{
    public async ValueTask<HttpResponseMessage> Get(CancellationToken cancellationToken)
    {
        HttpClient client = await clientProvider.Get(cancellationToken);
        return await client.GetAsync("account", cancellationToken);
    }
}
```

The wrapper lazily creates the client on the first `Get` call and returns that instance for its lifetime. Configuration is captured during creation; recreate the service lifetime to apply changed credentials or a changed base URL.

## Practical notes

- Do not dispose the returned `HttpClient`; the wrapper owns it. Dispose response messages and response streams you receive.
- The API key and token-owner email are attached as default headers. Redact them from HTTP logs, traces, and exception diagnostics.
- This package configures transport only. It does not add retries, rate-limit handling, pagination, response caching, or generated API methods.
