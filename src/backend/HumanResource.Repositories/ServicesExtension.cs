using HumanResource.Repositories.Contracts;
using HumanResource.Repositories.ODP;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResource.Services;

public static class ServicesExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IJobRepository, JobRepository>();
        services.AddScoped<IJobHistoryRepository, JobHistoryRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<IRegionRepository, RegionRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
