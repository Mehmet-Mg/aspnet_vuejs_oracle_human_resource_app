using HumanResource.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResource.Services;

public static class ServicesExtension
{
    public static IServiceCollection AddServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeManager>();
        services.AddScoped<IDepartmentService, DepartmentManager>();
        services.AddScoped<IServiceManager, ServiceManager>();
        return services;
    }
}
