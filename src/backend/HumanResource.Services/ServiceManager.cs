using HumanResource.Services.Contracts;

namespace HumanResource.Services;

public class ServiceManager : IServiceManager
{
    private readonly IEmployeeService _employeeService;
    private readonly IDepartmentService _departmentService;
    private readonly IJobService _jobService;
    private readonly ILocationService  _locationService;
    private readonly IRegionService _regionService;

    public ServiceManager(IEmployeeService employeeService, IDepartmentService departmentService, IJobService jobService, ILocationService locationService, IRegionService regionService)
    {
        _employeeService = employeeService;
        _departmentService = departmentService;
        _jobService = jobService;
        _locationService = locationService;
        _regionService = regionService;
    }

    public IEmployeeService EmployeeService => _employeeService;

    public IDepartmentService DepartmentService => _departmentService;

    public IJobService JobService => _jobService;

    public ILocationService LocationService => _locationService;

    public IRegionService RegionService => _regionService;
}
