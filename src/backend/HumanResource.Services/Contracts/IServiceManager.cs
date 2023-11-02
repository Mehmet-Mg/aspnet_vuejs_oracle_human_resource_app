namespace HumanResource.Services.Contracts;

public interface IServiceManager
{
    IEmployeeService EmployeeService { get; }
    IDepartmentService DepartmentService { get; }
    IJobService JobService { get; }
    ILocationService LocationService { get; }
    IRegionService RegionService { get; }
}
