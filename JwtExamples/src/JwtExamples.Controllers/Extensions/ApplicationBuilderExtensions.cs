using JwtExamples.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JwtExamples.ControllerApi.Extensions;

public static class ApplicationBuilderExtensions
{
    internal static void ApplyMigrations(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.CreateScope();

        using var applicationDbContext =
            scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        applicationDbContext.Database.Migrate();
    }
}