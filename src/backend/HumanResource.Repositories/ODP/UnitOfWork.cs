using HumanResource.Repositories.Contracts;

namespace HumanResource.Repositories.ODP;

public class UnitOfWork : IUnitOfWork
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IJobHistoryRepository _jobHistoryRepository;
    private readonly IJobRepository _jobRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly IRegionRepository _regionRepository;

    public UnitOfWork(IEmployeeRepository employeeRepository, 
                      IDepartmentRepository departmentRepository, 
                      IJobHistoryRepository jobHistoryRepository, 
                      IJobRepository jobRepository, 
                      ILocationRepository locationRepository, 
                      IRegionRepository regionRepository)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
        _jobHistoryRepository = jobHistoryRepository;
        _jobRepository = jobRepository;
        _locationRepository = locationRepository;
        _regionRepository = regionRepository;
    }

    public IEmployeeRepository EmployeeRepository => _employeeRepository;
    public IDepartmentRepository DepartmentRepository => _departmentRepository;
    public IJobRepository JobRepository => _jobRepository;
    public IJobHistoryRepository JobHistoryRepository => _jobHistoryRepository;
    public ILocationRepository LocationRepository => _locationRepository;
    public IRegionRepository RegionRepository => _regionRepository;

    public void Save()
    {
        throw new NotImplementedException();
    }
}
