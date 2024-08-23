using Box.V2.Config;
using Box.V2.JWTAuth;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace BoxAPIDemo.Controllers
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
        public async Task<string> Get()
        {
            string clientId = "";
            string clientSecret = "";

            var boxConfig = new BoxConfig(clientId, clientSecret,new Uri(""));
            var boxJWTAuth = new BoxJWTAuth(boxConfig);

            var boxClient = boxJWTAuth.AdminClient("");
            var user= await boxClient.UsersManager.GetCurrentUserInformationAsync();
          

            return "success";
        }
    }
}
