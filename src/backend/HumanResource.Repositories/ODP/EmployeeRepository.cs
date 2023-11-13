using HumanResource.Entities.Models;
using HumanResource.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace HumanResource.Repositories.ODP;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly string? _connectionString;

    public EmployeeRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("test");
    }

    public void Delete(int employeeId)
    {
        using (OracleConnection con = new OracleConnection(_connectionString))
        {
            using (OracleCommand cmd = con.CreateCommand())
            {
                try
                {
                    con.Open();
                    cmd.BindByName = true;

                    cmd.CommandText = @"DELETE FROM EMPLOYEES E
                                        WHERE
                                            E.EMPLOYEE_ID = :EMPLOYEE_ID";

                    OracleParameter employeeIdParam = new OracleParameter("employee_id", OracleDbType.Int32);
                    employeeIdParam.Direction = System.Data.ParameterDirection.Input;
                    employeeIdParam.Value = employeeId;
                    cmd.Parameters.Add(employeeIdParam);

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

    public Employee GetById<T>(T employeeId)
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
                                            employee_id, 
                                            first_name, 
                                            last_name, 
                                            email, 
                                            phone_number, 
                                            hire_date, 
                                            job_id, 
                                            salary, 
                                            commission_pct, 
                                            manager_id, 
                                            department_id 
                                        FROM employees 
                                        WHERE employee_id = :id";

                    OracleParameter id = new OracleParameter("id", employeeId);
                    cmd.Parameters.Add(id);

                    OracleDataReader reader = cmd.ExecuteReader();
                    Employee employee = null;
                    while (reader.Read())
                    {
                        employee = ConvertToEmployee(reader);
                    }

                    reader.Dispose();
                    id.Dispose();

                    return employee;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }

    public IEnumerable<Employee> All()
    {
        using (OracleConnection con = new OracleConnection(_connectionString))
        {
            using (OracleCommand cmd = con.CreateCommand())
            {
                try
                {
                    con.Open();
                    cmd.CommandText = @"SELECT 
                                            employee_id, 
                                            first_name, 
                                            last_name, 
                                            email, 
                                            phone_number, 
                                            hire_date, 
                                            job_id, 
                                            salary, 
                                            commission_pct, 
                                            manager_id, 
                                            department_id 
                                        FROM employees";

                    OracleDataReader reader = cmd.ExecuteReader();
                    List<Employee> employees = new List<Employee>();
                    while (reader.Read())
                    {
                        employees.Add(ConvertToEmployee(reader));
                    }

                    reader.Dispose();

                    return employees;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }

    public void Insert(Employee employee)
    {
        using (OracleConnection con = new OracleConnection(_connectionString))
        {
            using (OracleCommand cmd = con.CreateCommand())
            {
                try
                {
                    con.Open();
                    cmd.BindByName = true;

                    cmd.CommandText = @"INSERT INTO employees (
                                            first_name, 
                                            last_name, 
                                            email, 
                                            phone_number, 
                                            hire_date, 
                                            job_id, 
                                            salary, 
                                            commission_pct, 
                                            manager_id, 
                                            department_id
                                        ) VALUES (
                                            :first_name, 
                                            :last_name, 
                                            :email, 
                                            :phone_number, 
                                            :hire_date, 
                                            :job_id, 
                                            :salary, 
                                            :commission_pct, 
                                            :manager_id, 
                                            :department_id
                                        )";

                    OracleParameter firstNameParam = new OracleParameter("first_name", OracleDbType.Varchar2);
                    firstNameParam.Direction = System.Data.ParameterDirection.Input;
                    firstNameParam.Value = employee.FirstName;
                    cmd.Parameters.Add(firstNameParam);

                    OracleParameter lasttNameParam = new OracleParameter("last_name", OracleDbType.Varchar2);
                    lasttNameParam.Direction = System.Data.ParameterDirection.Input;
                    lasttNameParam.Value = employee.LastName;
                    cmd.Parameters.Add(lasttNameParam);

                    OracleParameter emailParam = new OracleParameter("email", OracleDbType.Varchar2);
                    emailParam.Direction = System.Data.ParameterDirection.Input;
                    emailParam.Value = employee.Email;
                    cmd.Parameters.Add(emailParam);

                    OracleParameter phoneNumberParam = new OracleParameter("phone_number", OracleDbType.Varchar2);
                    phoneNumberParam.Direction = System.Data.ParameterDirection.Input;
                    phoneNumberParam.Value = employee.PhoneNumber;
                    cmd.Parameters.Add(phoneNumberParam);

                    OracleParameter hireDateParam = new OracleParameter("hire_date", OracleDbType.Date);
                    hireDateParam.Direction = System.Data.ParameterDirection.Input;
                    hireDateParam.Value = employee.HireDate;
                    cmd.Parameters.Add(hireDateParam);

                    OracleParameter jobIdParam = new OracleParameter("job_id", OracleDbType.Varchar2);
                    jobIdParam.Direction = System.Data.ParameterDirection.Input;
                    jobIdParam.Value = employee.JobId;
                    cmd.Parameters.Add(jobIdParam);

                    OracleParameter salaryParam = new OracleParameter("salary", OracleDbType.Decimal);
                    salaryParam.Direction = System.Data.ParameterDirection.Input;
                    salaryParam.Value = employee.Salary;
                    cmd.Parameters.Add(salaryParam);

                    OracleParameter commissionPctParam = new OracleParameter("commission_pct", OracleDbType.Decimal);
                    commissionPctParam.Direction = System.Data.ParameterDirection.Input;
                    commissionPctParam.Value = employee.CommissionPct;
                    cmd.Parameters.Add(commissionPctParam);

                    OracleParameter managerIdParam = new OracleParameter("manager_id", OracleDbType.Int32);
                    managerIdParam.Direction = System.Data.ParameterDirection.Input;
                    managerIdParam.Value = employee.ManagerId;
                    cmd.Parameters.Add(managerIdParam);

                    OracleParameter departmentIdParam = new OracleParameter("department_id", OracleDbType.Int32);
                    departmentIdParam.Direction = System.Data.ParameterDirection.Input;
                    departmentIdParam.Value = employee.DepartmentId;
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

    public void Update(Employee employee)
    {
        using (OracleConnection con = new OracleConnection(_connectionString))
        {
            using (OracleCommand cmd = con.CreateCommand())
            {
                try
                {
                    con.Open();
                    cmd.BindByName = true;

                    cmd.CommandText = @"UPDATE EMPLOYEES E
                                        SET
                                            E.FIRST_NAME = :FIRST_NAME,
                                            E.LAST_NAME = :LAST_NAME,
                                            E.EMAIL = :EMAIL,
                                            E.PHONE_NUMBER = :PHONE_NUMBER,
                                            E.HIRE_DATE = :HIRE_DATE,
                                            E.JOB_ID = :JOB_ID,
                                            E.SALARY = :SALARY,
                                            E.COMMISSION_PCT = :COMMISSION_PCT,
                                            E.MANAGER_ID = :MANAGER_ID,
                                            E.DEPARTMENT_ID = :DEPARTMENT_ID
                                        WHERE
                                            E.EMPLOYEE_ID = :EMPLOYEE_ID";

                    OracleParameter employeeIdParam = new OracleParameter("employee_id", OracleDbType.Int32);
                    employeeIdParam.Direction = System.Data.ParameterDirection.Input;
                    employeeIdParam.Value = employee.EmployeeId;
                    cmd.Parameters.Add(employeeIdParam);

                    OracleParameter firstNameParam = new OracleParameter("first_name", OracleDbType.Varchar2);
                    firstNameParam.Direction = System.Data.ParameterDirection.Input;
                    firstNameParam.Value = employee.FirstName;
                    cmd.Parameters.Add(firstNameParam);

                    OracleParameter lasttNameParam = new OracleParameter("last_name", OracleDbType.Varchar2);
                    lasttNameParam.Direction = System.Data.ParameterDirection.Input;
                    lasttNameParam.Value = employee.LastName;
                    cmd.Parameters.Add(lasttNameParam);

                    OracleParameter emailParam = new OracleParameter("email", OracleDbType.Varchar2);
                    emailParam.Direction = System.Data.ParameterDirection.Input;
                    emailParam.Value = employee.Email;
                    cmd.Parameters.Add(emailParam);

                    OracleParameter phoneNumberParam = new OracleParameter("phone_number", OracleDbType.Varchar2);
                    phoneNumberParam.Direction = System.Data.ParameterDirection.Input;
                    phoneNumberParam.Value = employee.PhoneNumber;
                    cmd.Parameters.Add(phoneNumberParam);

                    OracleParameter hireDateParam = new OracleParameter("hire_date", OracleDbType.Date);
                    hireDateParam.Direction = System.Data.ParameterDirection.Input;
                    hireDateParam.Value = employee.HireDate;
                    cmd.Parameters.Add(hireDateParam);

                    OracleParameter jobIdParam = new OracleParameter("job_id", OracleDbType.Varchar2);
                    jobIdParam.Direction = System.Data.ParameterDirection.Input;
                    jobIdParam.Value = employee.JobId;
                    cmd.Parameters.Add(jobIdParam);

                    OracleParameter salaryParam = new OracleParameter("salary", OracleDbType.Decimal);
                    salaryParam.Direction = System.Data.ParameterDirection.Input;
                    salaryParam.Value = employee.Salary;
                    cmd.Parameters.Add(salaryParam);

                    OracleParameter commissionPctParam = new OracleParameter("commission_pct", OracleDbType.Decimal, ParameterDirection.Input);
                    commissionPctParam.Direction = System.Data.ParameterDirection.Input;
                    commissionPctParam.Value = employee.CommissionPct;
                    cmd.Parameters.Add(commissionPctParam);

                    OracleParameter managerIdParam = new OracleParameter("manager_id", OracleDbType.Int32);
                    managerIdParam.Direction = System.Data.ParameterDirection.Input;
                    managerIdParam.Value = employee.ManagerId;
                    cmd.Parameters.Add(managerIdParam);

                    OracleParameter departmentIdParam = new OracleParameter("department_id", OracleDbType.Int32);
                    departmentIdParam.Direction = System.Data.ParameterDirection.Input;
                    departmentIdParam.Value = employee.DepartmentId;
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

    public static Employee ConvertToEmployee(OracleDataReader reader)
    {
        return new Employee
        {
            EmployeeId = reader.GetInt32(0),
            FirstName = reader.GetString(1),
            LastName = reader.GetString(2),
            Email = reader.GetString(3),
            PhoneNumber = reader.IsDBNull(4) ? null : reader.GetString(4),
            HireDate = reader.GetDateTime(5),
            JobId = reader.GetString(6),
            Salary = reader.IsDBNull(7) ? null : reader.GetDecimal(7),
            CommissionPct = reader.IsDBNull(8) ? null : reader.GetDecimal(8),
            ManagerId = reader.IsDBNull(9) ? null : reader.GetInt32(9),
            DepartmentId = reader.IsDBNull(10) ? null : reader.GetInt32(10),
        };
    }
}
