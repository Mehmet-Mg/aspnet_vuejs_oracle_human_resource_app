using HumanResource.Entities.Models;
using HumanResource.Repositories.Contracts;
using HumanResource.Services.Contracts;

namespace HumanResource.Services;

public class JobManager : IJobService
{
    private readonly IUnitOfWork _unitOfWork;

    public JobManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Delete(int id)
    {
        _unitOfWork.EmployeeRepository.Delete(id);
    }

    public IEnumerable<Job> GetAll()
    {
        return _unitOfWork.JobRepository.All();
    }

    public Job GetById<T>(T id)
    {
        return _unitOfWork.JobRepository.GetById(id);
    }

    public void Insert(Job employee)
    {
        _unitOfWork.JobRepository.Insert(employee);
    }

    public void Update(Job employee)
    {
        _unitOfWork.JobRepository.Update(employee);
    }
}
