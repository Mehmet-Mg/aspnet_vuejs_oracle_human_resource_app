using HumanResource.Entities.Models;
using HumanResource.Repositories.Contracts;
using HumanResource.Services.Contracts;

namespace HumanResource.Services;

public class RegionManager : IRegionService
{
    private readonly IUnitOfWork _unitOfWork;

    public RegionManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Delete(int id)
    {
        _unitOfWork.RegionRepository.Delete(id);
    }

    public IEnumerable<Region> GetAll()
    {
        return _unitOfWork.RegionRepository.All();
    }

    public Region GetById<T>(T id)
    {
        return _unitOfWork.RegionRepository.GetById(id);
    }

    public void Insert(Region employee)
    {
        _unitOfWork.RegionRepository.Insert(employee);
    }

    public void Update(Region employee)
    {
        _unitOfWork.RegionRepository.Update(employee);
    }
}
