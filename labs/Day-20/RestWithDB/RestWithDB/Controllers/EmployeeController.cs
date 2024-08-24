using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithDB.DBConnections;
using RestWithDB.ViewModel;
using System.Data.SqlClient;

namespace RestWithDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeDBContext db = new EmployeeDBContext();

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var employees = new List<Employee>();
            SqlDataReader srdr= db.GetData("select * from tblEmployee");
            while (srdr.Read())
            {
                employees.Add(new Employee
                {
                    Id = (int)srdr["Id"],
                    EmployeeName = (string)srdr["EmployeeName"],
                });
            }
            db.CloseConnection();
            return employees;
        }
    }
}
