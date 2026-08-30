using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
namespace Soenneker.Copper.HttpClients.Abstract;

/// <summary>
/// Provides a cached, authenticated <see cref="HttpClient"/> for Copper's Developer API.
/// </summary>
public interface ICopperOpenApiHttpClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured HTTP client owned by this wrapper.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the cached HTTP client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
