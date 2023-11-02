namespace HumanResource.Repositories.Contracts;

public interface IUnitOfWork
{
    void Save();
    IEmployeeRepository EmployeeRepository { get; }
    IDepartmentRepository DepartmentRepository { get; }
    IJobRepository JobRepository { get; }
    IJobHistoryRepository JobHistoryRepository { get; }
    ILocationRepository LocationRepository { get; }
    IRegionRepository RegionRepository { get; }
}
