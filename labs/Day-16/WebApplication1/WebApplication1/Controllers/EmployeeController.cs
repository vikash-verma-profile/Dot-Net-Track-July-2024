using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public static List<Employee> employeeList = new List<Employee>();
        [HttpGet("get-employees")]
        public IEnumerable<Employee> GetEmployee()
        {
            return employeeList;
        }
        [HttpGet("get-employee")]
        public Employee GetEmployee(int Id)
        {
            return employeeList.Where(x=>x.Id== Id).FirstOrDefault();
        }
        [HttpPost]
        public IActionResult PostEmployee(Employee employee)
        {
            employeeList.Add(employee);
            return Ok("Record added successfully");
        }
        [HttpPut]
        public IActionResult PutEmployee(Employee employee)
        {
            var employeeData=employeeList.Where(x=>x.Id==employee.Id).FirstOrDefault();
            employeeList.Remove(employeeData);
            employeeList.Add(employee);
            return Ok("Record updated successfully");
        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int Id)
        {
            var employeeData = employeeList.Where(x => x.Id == Id).FirstOrDefault();
            employeeList.Remove(employeeData);
            return Ok("Record deleted successfully");
        }
    }
}
