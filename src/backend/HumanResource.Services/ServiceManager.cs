using HumanResource.Services.Contracts;

namespace HumanResource.Services;

public class ServiceManager : IServiceManager
{
    private readonly IEmployeeService _employeeService;
    private readonly IDepartmentService _departmentService;

    public ServiceManager(IEmployeeService employeeService, IDepartmentService departmentService)
    {
        _employeeService = employeeService;
        _departmentService = departmentService;
    }

    public IEmployeeService EmployeeService => _employeeService;

    public IDepartmentService DepartmentService => _departmentService;
}
