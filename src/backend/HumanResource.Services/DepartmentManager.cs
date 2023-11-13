using HumanResource.Entities.Models;
using HumanResource.Repositories.Contracts;
using HumanResource.Services.Contracts;

namespace HumanResource.Services;

public class DepartmentManager : IDepartmentService
{
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Delete(int id)
    {
        _unitOfWork.DepartmentRepository.Delete(id);
    }

    public IEnumerable<Department> GetAll()
    {
        return _unitOfWork.DepartmentRepository.All();
    }

    public Department GetById<T>(T id)
    {
        return _unitOfWork.DepartmentRepository.GetById(id);
    }

    public void Insert(Department entity)
    {
        _unitOfWork.DepartmentRepository.Insert(entity);
    }

    public void Update(Department entity)
    {
        _unitOfWork.DepartmentRepository.Update(entity);
    }
}
