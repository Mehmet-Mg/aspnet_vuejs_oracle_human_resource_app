﻿namespace HumanResource.Entities.Models;

public class Department
{
    public int DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public int? ManagerId { get; set; }
    public int LocationId { get; set; }
}
