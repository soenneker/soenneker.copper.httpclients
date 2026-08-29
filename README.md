[![](https://img.shields.io/nuget/v/soenneker.copper.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.copper.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.copper.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.copper.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.copper.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.copper.httpclients/)

# Soenneker.Copper.HttpClients

A .NET thread-safe singleton HttpClient for.

## Install

```bash
dotnet add package Soenneker.Copper.HttpClients
```

## Quick start

```csharp
using Soenneker.Copper.HttpClients.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddCopperOpenApiHttpClientAsSingleton();
```

Adds `CopperOpenApiHttpClient` as a singleton service.

## What you get

- `ICopperOpenApiHttpClient` — A .NET thread-safe singleton HttpClient for.
- `CopperOpenApiHttpClientRegistrar` — Registers the OpenAPI HttpClient wrapper for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `CopperOpenApiHttpClientRegistrar.AddCopperOpenApiHttpClientAsSingleton(services)` | Adds `CopperOpenApiHttpClient` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `CopperOpenApiHttpClientRegistrar.AddCopperOpenApiHttpClientAsScoped(services)` | Adds `CopperOpenApiHttpClient` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
