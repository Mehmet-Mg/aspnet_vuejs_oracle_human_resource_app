using HumanResource.Entities.Models;
using HumanResource.Repositories.Contracts;
using HumanResource.Services.Contracts;

namespace HumanResource.Services;

public class LocationManager : ILocationService
{
    private readonly IUnitOfWork _unitOfWork;

    public LocationManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Delete(int id)
    {
        _unitOfWork.LocationRepository.Delete(id);
    }

    public IEnumerable<Location> GetAll()
    {
        return _unitOfWork.LocationRepository.All();
    }

    public Location GetById<T>(T id)
    {
        return _unitOfWork.LocationRepository.GetById(id);
    }

    public void Insert(Location employee)
    {
        _unitOfWork.LocationRepository.Insert(employee);
    }

    public void Update(Location employee)
    {
        _unitOfWork.LocationRepository.Update(employee);
    }
}
