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
