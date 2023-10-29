namespace HumanResource.Repositories.Contracts;

public interface IUnitOfWork
{
    void Save();
    IEmployeeRepository EmployeeRepository { get; }
    IDepartmentRepository DepartmentRepository { get; }
}
