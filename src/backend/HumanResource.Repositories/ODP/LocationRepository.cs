using HumanResource.Entities.Models;
using HumanResource.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace HumanResource.Repositories.ODP;

public class LocationRepository : ILocationRepository
{
    private readonly string? _connectionString;

    public LocationRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("test");
    }

    public IEnumerable<Location> All()
    {
        using (OracleConnection con = new OracleConnection(_connectionString))
        {
            using(OracleCommand cmd = con.CreateCommand())
            {
                con.Open();

                cmd.CommandText = @"SELECT
	                                    l.LOCATION_ID ,
	                                    l.STREET_ADDRESS ,
	                                    l.POSTAL_CODE ,
	                                    l.CITY ,
	                                    l.STATE_PROVINCE ,
	                                    l.COUNTRY_ID
                                    FROM
	                                    LOCATIONS l";
                
                OracleDataReader reader = cmd.ExecuteReader();
                
                List<Location> results = new List<Location>();
                while (reader.Read())
                {
                    results.Add(ConvertToLocation(reader));
                }
                return results;
            }
        }
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Location GetById<T>(T id)
    {
        using (OracleConnection con = new OracleConnection(_connectionString))
        {
            using (OracleCommand cmd = con.CreateCommand())
            {
                con.Open();

                cmd.BindByName = true;
                cmd.CommandText = @"SELECT
	                                    l.LOCATION_ID ,
	                                    l.STREET_ADDRESS ,
	                                    l.POSTAL_CODE ,
	                                    l.CITY ,
	                                    l.STATE_PROVINCE ,
	                                    l.COUNTRY_ID
                                    FROM
	                                    LOCATIONS l
                                    WHERE
                                        l.LOCATION_ID = :location_id";

                OracleParameter locationIdParam = new OracleParameter("location_id", id);
                cmd.Parameters.Add(locationIdParam);

                OracleDataReader reader = cmd.ExecuteReader();

                Location result = null;
                while (reader.Read())
                {
                    result = ConvertToLocation(reader);
                }
                return result;
            }
        }
    }

    public void Insert(Location entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Location entity)
    {
        throw new NotImplementedException();
    }

    public static Location ConvertToLocation(OracleDataReader reader)
    {
        return new Location
        {
            LocationId = reader.IsDBNull(0) ? default : reader.GetInt32(0),
            StreetAddress = reader.IsDBNull(1) ?default : reader.GetString(1),
            PostalCode = reader.IsDBNull(2) ? default : reader.GetString(2),
            City = reader.IsDBNull(3) ? default : reader.GetString(3),
            StateProvince = reader.IsDBNull(4) ? default : reader.GetString(4),
            CountryId = reader.GetString(5),
        };
    }
}
