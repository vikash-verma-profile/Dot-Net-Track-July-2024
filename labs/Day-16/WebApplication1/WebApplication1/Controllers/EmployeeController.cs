using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public Employee GetEmployee()
        {
            return new Employee { Id=123,Name="Vikash Verma",Gender="Male",Salary=1000};
        }
    }
}
