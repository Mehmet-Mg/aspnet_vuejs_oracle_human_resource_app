using HumanResource.Entities.Models;
using HumanResource.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace HumanResource.Repositories.ODP;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly string? _connectionString;

    public DepartmentRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("test");
    }

    public void Delete(int departmentId)
    {
        using (OracleConnection con = new OracleConnection(_connectionString))
        {
            using (OracleCommand cmd = con.CreateCommand())
            {
                try
                {
                    con.Open();
                    cmd.BindByName = true;

                    cmd.CommandText = @"DELETE FROM departments d 
                                            WHERE d.department_id  = :department_id";

                    OracleParameter departmentIdParam = new OracleParameter("department_id", OracleDbType.Int32);
                    departmentIdParam.Direction = System.Data.ParameterDirection.Input;
                    departmentIdParam.Value = departmentIdParam;
                    cmd.Parameters.Add(departmentIdParam);

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

    public Department GetById(object departmentId)
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
                                            department_id, 
                                            department_name, 
                                            manager_id, 
                                            location_id 
                                        FROM departments
                                        WHERE department_id = :id";

                    OracleParameter id = new OracleParameter("id", departmentId);
                    cmd.Parameters.Add(id);

                    OracleDataReader reader = cmd.ExecuteReader();
                    Department department = null;
                    while (reader.Read())
                    {
                        if (department is null)
                        {
                            department = new Department
                            {
                                DepartmentId = reader.GetInt32(0),
                                DepartmentName = reader.GetString(1),
                                ManagerId = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                                LocationId = reader.GetInt32(3),
                            };
                        }
                    }

                    reader.Dispose();
                    id.Dispose();

                    return department;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }

    public IEnumerable<Department> All()
    {
        using (OracleConnection con = new OracleConnection(_connectionString))
        {
            using (OracleCommand cmd = con.CreateCommand())
            {
                try
                {
                    con.Open();
                    cmd.CommandText = @"SELECT 
                                            department_id, 
                                            department_name, 
                                            manager_id, 
                                            location_id 
                                        FROM departments";

                    //cmd.BindByName = true;
                    //OracleParameter id = new OracleParameter("id", 50);

                    OracleDataReader reader = cmd.ExecuteReader();
                    List<Department> departments = new List<Department>();
                    while (reader.Read())
                    {
                        departments.Add(
                            new Department
                            {
                                DepartmentId = reader.GetInt32(0),
                                DepartmentName = reader.GetString(1),
                                ManagerId = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                                LocationId = reader.GetInt32(3),
                            });
                    }

                    reader.Dispose();

                    return departments;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }

    public void Insert(Department department)
    {
        using (OracleConnection con = new OracleConnection(_connectionString))
        {
            using (OracleCommand cmd = con.CreateCommand())
            {
                try
                {
                    con.Open();
                    cmd.BindByName = true;

                    cmd.CommandText = @"INSERT INTO departments (
                                            department_name, 
                                            manager_id,
                                            location_id
                                        ) VALUES (
                                            :department_name, 
                                            :manager_id, 
                                            :location_id
                                        )";

                    OracleParameter departmentNameParam = new OracleParameter("department_name", OracleDbType.Varchar2);
                    departmentNameParam.Direction = System.Data.ParameterDirection.Input;
                    departmentNameParam.Value = department.DepartmentName;
                    cmd.Parameters.Add(departmentNameParam);

                    OracleParameter managerIdParam = new OracleParameter("manager_id", OracleDbType.Int32);
                    managerIdParam.Direction = System.Data.ParameterDirection.Input;
                    managerIdParam.Value = department.ManagerId;
                    cmd.Parameters.Add(managerIdParam);

                    OracleParameter locationIdParam = new OracleParameter("location_id", OracleDbType.Int32);
                    locationIdParam.Direction = System.Data.ParameterDirection.Input;
                    locationIdParam.Value = department.LocationId;
                    cmd.Parameters.Add(locationIdParam);

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

    public void Update(Department department)
    {
        using (OracleConnection con = new OracleConnection(_connectionString))
        {
            using (OracleCommand cmd = con.CreateCommand())
            {
                try
                {
                    con.Open();
                    cmd.BindByName = true;

                    cmd.CommandText = @"UPDATE departments d 
	                                        SET d.department_name = :department_name,
	                                        d.manager_id = :manager_id,
	                                        d.location_id = :location_id
	                                        WHERE d.department_id  = :department_id";

                    OracleParameter departmentIdParam = new OracleParameter("department_id", OracleDbType.Int32);
                    departmentIdParam.Direction = System.Data.ParameterDirection.Input;
                    departmentIdParam.Value = department.DepartmentId;
                    cmd.Parameters.Add(departmentIdParam);

                    OracleParameter departmentNameParam = new OracleParameter("department_name", OracleDbType.Varchar2);
                    departmentNameParam.Direction = System.Data.ParameterDirection.Input;
                    departmentNameParam.Value = department.DepartmentName;
                    cmd.Parameters.Add(departmentNameParam);

                    OracleParameter managerIdParam = new OracleParameter("manager_id", OracleDbType.Int32);
                    managerIdParam.Direction = System.Data.ParameterDirection.Input;
                    managerIdParam.Value = department.ManagerId;
                    cmd.Parameters.Add(managerIdParam);

                    OracleParameter locationIdParam = new OracleParameter("location_id", OracleDbType.Int32);
                    locationIdParam.Direction = System.Data.ParameterDirection.Input;
                    locationIdParam.Value = department.LocationId;
                    cmd.Parameters.Add(locationIdParam);

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
