using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CompanyTest.Application;
public static class ApplicationServicesExtension
{
    public static IServiceCollection AddApplicationServices(
       this IServiceCollection services,
       List<Assembly> mediatRAssemblies)
    {
        mediatRAssemblies.Add(typeof(ApplicationServicesExtension).Assembly);

        return services;
    }
}
