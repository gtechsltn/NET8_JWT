using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using JwtExamples.MinimalApi.Abstractions;

namespace JwtExamples.MinimalApi.Extensions;

public static class EndpointExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var descriptors = assembly.DefinedTypes
            .Where(type => type.IsClass && type.IsAssignableTo(typeof(IEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
            .ToArray();

        services.TryAddEnumerable(descriptors);

        return services;
    }

    public static IApplicationBuilder MapEndpoints(this WebApplication app)
    {
        var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

        foreach (var endpoint in endpoints)
        {
            endpoint.MapEndpoint(app);
        }

        return app;
    }
}