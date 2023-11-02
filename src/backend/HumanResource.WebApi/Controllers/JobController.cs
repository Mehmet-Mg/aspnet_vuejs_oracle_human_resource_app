using HumanResource.Entities.Models;
using HumanResource.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.API.Controllers;

[ApiController]
[Route("[controller]")]
public class JobController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    private readonly ILogger<JobController> _logger;

    public JobController(IServiceManager serviceManager, ILogger<JobController> logger)
    {
        _serviceManager = serviceManager;
        _logger = logger;
    }

    [HttpGet(Name = "GetJobs")]
    public IEnumerable<Job> GetJobs()
    {
        return _serviceManager.JobService.GetAll();
    }

    [HttpGet("{jobId}")]
    public Job GetJobById(string jobId)
    {
        return _serviceManager.JobService.GetById(jobId);
    }
}