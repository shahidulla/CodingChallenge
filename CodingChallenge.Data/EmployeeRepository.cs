using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using SunIT.Entity;

namespace CodingChallenge.Data
{
    public class EmployeeRepository
    {
        public bool SaveEmployee(Employee employee)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=EmployeeBenefits;Integrated Security=True"))
                {
                    string sqlQuery = "INSERT INTO [dbo].[Employee](FirstName, LastName, CreatedDate) OUTPUT INSERTED.[Id]";
                    sqlQuery += "VALUES(@FirstName, @LastName, @CreatedDate)";
                    employee.Id = conn.Query<int>(sqlQuery, employee, commandTimeout: 30, commandType: CommandType.Text).Single();

                    foreach (var dependent in employee.Dependents)
                    {
                        dependent.EmployeeId = employee.Id;
                        sqlQuery = "INSERT INTO [dbo].[Dependent](EmployeeId, FirstName, LastName, DependentType, CreatedDate)";
                        sqlQuery += "VALUES(@EmployeeId,@FirstName,@LastName,@DependentType,@CreatedDate)";
                        conn.Query(sqlQuery, dependent, commandTimeout: 30, commandType: CommandType.Text);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
