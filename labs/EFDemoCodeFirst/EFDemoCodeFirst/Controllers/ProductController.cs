using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFDemoCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
