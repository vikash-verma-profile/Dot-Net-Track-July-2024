using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public static List<Employee> employeeList = new List<Employee>();
        [HttpGet]
        public IEnumerable<Employee> GetEmployee()
        {
            return employeeList;
        }
        //[HttpGet]
        //public IEnumerable<Employee> GetEmployee()
        //{
        //    return employeeList;
        //}
        [HttpPost]
        public IActionResult PostEmployee(Employee employee)
        {
            employeeList.Add(employee);
            return Ok("Record added successfully");
        }
    }
}
