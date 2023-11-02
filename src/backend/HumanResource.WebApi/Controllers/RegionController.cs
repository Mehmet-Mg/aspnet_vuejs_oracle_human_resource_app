using HumanResource.Entities.Models;
using HumanResource.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RegionController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    private readonly ILogger<RegionController> _logger;

    public RegionController(IServiceManager serviceManager, ILogger<RegionController> logger)
    {
        _serviceManager = serviceManager;
        _logger = logger;
    }

    [HttpGet(Name = "GetRegions")]
    public IEnumerable<Region> GetRegions()
    {
        return _serviceManager.RegionService.GetAll();
    }

    [HttpGet("{regionId}")]
    public Region GetRegionById(int regionId)
    {
        return _serviceManager.RegionService.GetById(regionId);
    }
}