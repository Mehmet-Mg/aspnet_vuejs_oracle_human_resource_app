using HumanResource.Entities.Models;
using HumanResource.Repositories.Contracts;
using Microsoft.Extensions.Configuration;

namespace HumanResource.Repositories.ODP;

public class JobHistoryRepository : IJobHistoryRepository
{
    private readonly string? _connectionString;

    public JobHistoryRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("test");
    }

    public IEnumerable<Job> All()
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Job GetById(object id)
    {
        throw new NotImplementedException();
    }

    public void Insert(Job entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Job entity)
    {
        throw new NotImplementedException();
    }
}
