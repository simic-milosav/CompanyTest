using CompanyTest.Contracts.UnitOfWork;
using CompanyTest.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyTest.Infrastructure;
public static class InfrastructureServicesExtension
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

        string connectionString = configuration.GetConnectionString("Database")!;

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString, sqloptions =>
            {
                sqloptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, ApplicationDbContext.Schema);
            }
        ));

        return services;
    }
}
