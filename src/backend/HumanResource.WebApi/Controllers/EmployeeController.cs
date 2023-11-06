using HumanResource.Entities.Models;
using HumanResource.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(IServiceManager serviceManager, ILogger<EmployeeController> logger)
    {
        _serviceManager = serviceManager;
        _logger = logger;
    }

    [HttpGet(Name = "GetEmployees")]
    public IEnumerable<Employee> GetEmployees()
    {
        return _serviceManager.EmployeeService.GetAll();
    }

    [HttpGet("{employeeId:int}")]
    public Employee GetEmployeeById(int employeeId)
    {
        return _serviceManager.EmployeeService.GetById(employeeId);
    }

    [HttpPost]
    public void InsertEmployee([FromBody] Employee employee)
    {
        _serviceManager.EmployeeService.Insert(employee);
    }

    [HttpPut("{employeeId:int}")]
    public void UpdateEmployee(int employeeId, [FromBody] Employee employee)
    {
        if (employeeId != employee.EmployeeId)
        {
            throw new Exception("Employee Id is wrong!.");
        }
        _serviceManager.EmployeeService.Update(employee);
    }

    [HttpDelete("{employeeId:int}")]
    public void DeleteEmployee(int employeeId)
    {
        _serviceManager.EmployeeService.Delete(employeeId);
    }
}