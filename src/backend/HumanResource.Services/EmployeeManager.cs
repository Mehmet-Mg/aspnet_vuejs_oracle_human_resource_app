using HumanResource.Entities.Models;
using HumanResource.Repositories.Contracts;
using HumanResource.Services.Contracts;

namespace HumanResource.Services;

public class EmployeeManager : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Delete(int id)
    {
        _unitOfWork.EmployeeRepository.Delete(id);
    }

    public IEnumerable<Employee> GetAll()
    {
        return _unitOfWork.EmployeeRepository.All();
    }

    public Employee GetById(object id)
    {
        return _unitOfWork.EmployeeRepository.GetById(id);
    }

    public void Insert(Employee employee)
    {
        _unitOfWork.EmployeeRepository.Insert(employee);
    }

    public void Update(Employee employee)
    {
        _unitOfWork.EmployeeRepository.Update(employee);
    }
}
