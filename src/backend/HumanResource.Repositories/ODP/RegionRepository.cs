using HumanResource.Entities.Models;
using HumanResource.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace HumanResource.Repositories.ODP;

public class RegionRepository : IRegionRepository
{
    private readonly string? _connectionString;

    public RegionRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("test");
    }

    public IEnumerable<Region> All()
    {
        using (OracleConnection con = new OracleConnection(_connectionString))
        {
            using (OracleCommand cmd = con.CreateCommand())
            {
                try
                {
                    con.Open();
                    cmd.CommandText = @"SELECT
	                                        r.REGION_ID ,
	                                        r.REGION_NAME
                                        FROM
	                                        REGIONS r";

                    OracleDataReader reader = cmd.ExecuteReader();
                    List<Region> regions = new List<Region>();
                    while (reader.Read())
                    {
                        regions.Add(ConvertToRegion(reader));
                    }

                    reader.Dispose();

                    return regions;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Region GetById<T>(T regionId)
    {
        using (OracleConnection con = new OracleConnection(_connectionString))
        {
            using (OracleCommand cmd = con.CreateCommand())
            {
                try
                {
                    con.Open();

                    cmd.BindByName = true;
                    cmd.CommandText = @"SELECT
	                                        r.REGION_ID ,
	                                        r.REGION_NAME
                                        FROM
	                                        REGIONS r
                                        WHERE r.REGION_ID = :id";

                    OracleParameter id = new OracleParameter("id", regionId);
                    cmd.Parameters.Add(id);

                    OracleDataReader reader = cmd.ExecuteReader();
                    Region region = null;
                    while (reader.Read())
                    {
                        region = ConvertToRegion(reader);
                    }

                    reader.Dispose();

                    return region;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }

    public void Insert(Region entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Region entity)
    {
        throw new NotImplementedException();
    }

    public static Region ConvertToRegion(OracleDataReader reader)
    {
        return new Region
        {
            RegionId = reader.GetInt32(0),
            RegionName = reader.GetString(1),
        };
    }
}
