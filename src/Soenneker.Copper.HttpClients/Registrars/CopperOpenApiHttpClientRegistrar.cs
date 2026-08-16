using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Copper.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Copper.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class CopperOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="CopperOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddCopperOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<ICopperOpenApiHttpClient, CopperOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="CopperOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddCopperOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<ICopperOpenApiHttpClient, CopperOpenApiHttpClient>();

        return services;
    }
}
