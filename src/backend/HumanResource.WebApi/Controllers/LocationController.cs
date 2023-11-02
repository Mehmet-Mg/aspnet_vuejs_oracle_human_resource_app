using HumanResource.Entities.Models;
using HumanResource.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    private readonly ILogger<LocationController> _logger;

    public LocationController(IServiceManager serviceManager, ILogger<LocationController> logger)
    {
        _serviceManager = serviceManager;
        _logger = logger;
    }

    [HttpGet(Name = "GetLocations")]
    public IEnumerable<Location> GetLocations()
    {
        return _serviceManager.LocationService.GetAll();
    }

    [HttpGet("{locationId}")]
    public Location GetLocationById(int locationId)
    {
        return _serviceManager.LocationService.GetById(locationId);
    }
}