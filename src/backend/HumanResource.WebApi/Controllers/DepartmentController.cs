using HumanResource.Entities.Models;
using HumanResource.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.API.Controllers;


[ApiController]
[Route("[controller]")]
public class DepartmentController : Controller
{
    private readonly IServiceManager _serviceManager;
    private readonly ILogger<DepartmentController> _logger;

    public DepartmentController(IServiceManager serviceManager, ILogger<DepartmentController> logger)
    {
        _serviceManager = serviceManager;
        _logger = logger;
    }

    [HttpGet(Name = "GetDepartments")]
    public IEnumerable<Department> GetDepartments()
    {
        return _serviceManager.DepartmentService.GetAll();
    }

    [HttpGet("{departmentId:int}")]
    public Department GetEmployeeById(int departmentId)
    {
        return _serviceManager.DepartmentService.GetById(departmentId);
    }

    [HttpPost]
    public void InsertDepartment([FromBody] Department department)
    {
        _serviceManager.DepartmentService.Insert(department);
    }

    [HttpPut("{departmentId:int}")]
    public void UpdateDepartment(int departmentId, [FromBody] Department department)
    {
        if (departmentId != department.DepartmentId)
        {
            throw new Exception("Department Id is wrong!.");
        }
        _serviceManager.DepartmentService.Update(department);
    }

    [HttpDelete("{departmentId:int}")]
    public void DeleteDepartment(int departmentId)
    {
        _serviceManager.DepartmentService.Delete(departmentId);
    }
}
