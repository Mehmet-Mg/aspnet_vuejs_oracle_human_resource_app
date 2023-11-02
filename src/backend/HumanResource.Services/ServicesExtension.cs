using HumanResource.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResource.Services;

public static class ServicesExtension
{
    public static IServiceCollection AddServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeManager>();
        services.AddScoped<IDepartmentService, DepartmentManager>();
        services.AddScoped<IJobService, JobManager>();
        services.AddScoped<ILocationService, LocationManager>();
        services.AddScoped<IRegionService, RegionManager>();
        services.AddScoped<IServiceManager, ServiceManager>();
        return services;
    }
}
