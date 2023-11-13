using HumanResource.Entities.Models;
using HumanResource.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace HumanResource.Repositories.ODP;

public class JobRepository : IJobRepository
{
    private readonly string? _connectionString;

    public JobRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("test");
    }

    public IEnumerable<Job> All()
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
	                                        j.JOB_ID ,
	                                        j.JOB_TITLE ,
	                                        j.MIN_SALARY ,
	                                        j.MAX_SALARY
                                        FROM
	                                        JOBS j";

                    OracleDataReader reader = cmd.ExecuteReader();
                    List<Job> jobs = new List<Job>();
                    while (reader.Read())
                    {
                        jobs.Add(new Job
                        {
                            JobId = reader.GetString(0),
                            JobTitle = reader.GetString(1),
                            MinSalary = reader.GetDecimal(2),
                            MaxSalary = reader.GetDecimal(3),
                        });
                    }

                    reader.Dispose();

                    return jobs;
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
        using (OracleConnection con = new OracleConnection(_connectionString))
        {
            using (OracleCommand cmd = con.CreateCommand())
            {
                try
                {
                    con.Open();
                    cmd.BindByName = true;

                    cmd.CommandText = @"DELETE FROM jobs j 
                                            WHERE j.job_id  = :job_id";

                    OracleParameter jobIdParam = new OracleParameter("job_id", OracleDbType.Int32);
                    jobIdParam.Direction = System.Data.ParameterDirection.Input;
                    jobIdParam.Value = id;
                    cmd.Parameters.Add(jobIdParam);

                    cmd.ExecuteNonQuery();

                    cmd.Dispose();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }

    public Job GetById<T>(T id)
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
	                                        j.JOB_ID ,
	                                        j.JOB_TITLE ,
	                                        j.MIN_SALARY ,
	                                        j.MAX_SALARY
                                        FROM
	                                        JOBS j
                                        WHERE
	                                        j.JOB_ID = :job_id";

                    OracleParameter jobIdParam = new OracleParameter("job_id", id);
                    cmd.Parameters.Add(jobIdParam);

                    OracleDataReader reader = cmd.ExecuteReader();
                    Job job = null;
                    while (reader.Read())
                    {
                        if (job is null)
                        {
                            job = new Job
                            {
                                JobId = reader.GetString(0),
                                JobTitle = reader.GetString(1),
                                MinSalary = reader.GetDecimal(2),
                                MaxSalary = reader.GetDecimal(3),
                            };
                        }
                    }

                    reader.Dispose();
                    jobIdParam.Dispose();

                    return job;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }

    public void Insert(Job entity)
    {
        using (OracleConnection con = new OracleConnection(_connectionString))
        {
            using (OracleCommand cmd = con.CreateCommand())
            {
                try
                {
                    con.Open();
                    cmd.BindByName = true;

                    cmd.CommandText = @"INSERT INTO jobs (
                                            job_id, 
                                            job_title, 
                                            min_salary, 
                                            max_salary
                                        ) VALUES (
                                            :job_id, 
                                            :job_title, 
                                            :min_salary, 
                                            :max_salary
                                        )";

                    OracleParameter jobIdParam = new OracleParameter("job_id", OracleDbType.Varchar2);
                    jobIdParam.Direction = System.Data.ParameterDirection.Input;
                    jobIdParam.Value = entity.JobId;
                    cmd.Parameters.Add(jobIdParam);

                    OracleParameter jobTitleParam = new OracleParameter("job_title", OracleDbType.Varchar2);
                    jobTitleParam.Direction = System.Data.ParameterDirection.Input;
                    jobTitleParam.Value = entity.JobTitle;
                    cmd.Parameters.Add(jobTitleParam);

                    OracleParameter minSalaryParam = new OracleParameter("min_salary", OracleDbType.Decimal);
                    minSalaryParam.Direction = System.Data.ParameterDirection.Input;
                    minSalaryParam.Value = entity.MinSalary;
                    cmd.Parameters.Add(minSalaryParam);

                    OracleParameter maxSalaryParam = new OracleParameter("max_salary", OracleDbType.Decimal);
                    maxSalaryParam.Direction = System.Data.ParameterDirection.Input;
                    maxSalaryParam.Value = entity.MaxSalary;
                    cmd.Parameters.Add(maxSalaryParam);

                    cmd.ExecuteNonQuery();

                    cmd.Dispose();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }

    public void Update(Job entity)
    {
        using (OracleConnection con = new OracleConnection(_connectionString))
        {
            using (OracleCommand cmd = con.CreateCommand())
            {
                try
                {
                    con.Open();
                    cmd.BindByName = true;

                    cmd.CommandText = @"UPDATE
	                                        JOBS J
                                        SET
	                                        j.JOB_TITLE = :job_title,
	                                        j.MIN_SALARY = :min_salary,
	                                        j.MAX_SALARY = :max_salary
                                        WHERE
	                                        j.JOB_ID = :job_id";

                    OracleParameter jobIdParam = new OracleParameter("job_id", OracleDbType.Varchar2);
                    jobIdParam.Direction = System.Data.ParameterDirection.Input;
                    jobIdParam.Value = entity.JobId;
                    cmd.Parameters.Add(jobIdParam);

                    OracleParameter jobTitleParam = new OracleParameter("job_title", OracleDbType.Varchar2);
                    jobTitleParam.Direction = System.Data.ParameterDirection.Input;
                    jobTitleParam.Value = entity.JobTitle;
                    cmd.Parameters.Add(jobTitleParam);

                    OracleParameter minSalaryParam = new OracleParameter("min_salary", OracleDbType.Decimal);
                    minSalaryParam.Direction = System.Data.ParameterDirection.Input;
                    minSalaryParam.Value = entity.MinSalary;
                    cmd.Parameters.Add(minSalaryParam);

                    OracleParameter maxSalaryParam = new OracleParameter("max_salary", OracleDbType.Decimal);
                    maxSalaryParam.Direction = System.Data.ParameterDirection.Input;
                    maxSalaryParam.Value = entity.MaxSalary;
                    cmd.Parameters.Add(maxSalaryParam);

                    cmd.ExecuteNonQuery();

                    cmd.Dispose();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
