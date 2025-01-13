using CompanyTest.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CompanyTest.API.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using ApplicationDbContext certificatesContext = scope.ServiceProvider.GetService<ApplicationDbContext>()!;

        certificatesContext.Database.Migrate();
    }
}
