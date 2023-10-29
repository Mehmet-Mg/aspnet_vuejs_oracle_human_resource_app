using HumanResource.Repositories.Contracts;

namespace HumanResource.Repositories.ODP;

public class UnitOfWork : IUnitOfWork
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDepartmentRepository _departmentRepository;

    public UnitOfWork(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
    }

    public IEmployeeRepository EmployeeRepository => _employeeRepository;
    public IDepartmentRepository DepartmentRepository => _departmentRepository;


    public void Save()
    {
        throw new NotImplementedException();
    }
}
