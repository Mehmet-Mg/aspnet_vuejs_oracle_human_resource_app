namespace HumanResource.Entities.Models;

public class Job
{
    public string? JobId { get; set; }
    public string? JobTitle { get; set; }
    public decimal? MinSalary { get; set; }
    public decimal? MaxSalary { get; set; }
}
