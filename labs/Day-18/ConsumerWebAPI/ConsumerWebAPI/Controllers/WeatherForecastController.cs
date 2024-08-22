using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using System.Linq.Expressions;

namespace ConsumerWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<int> Get()
        {
            var client = new ServiceReference1.AuthorServiceClient();
            MySoapMethodRequest soapRequest = new MySoapMethodRequest();
            soapRequest.num1 = 1;
            soapRequest.num2 = 2;

            MySoapMethodResponse result = await client.MySoapMethodAsync(soapRequest);
            return result.MySoapMethodResult;
        }
    }
}
