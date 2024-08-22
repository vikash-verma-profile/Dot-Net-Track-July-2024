using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using Newtonsoft.Json;

namespace ServiceNowDemo.Controllers
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

        public class Incident
        {
            public string ShortDescription { get; set; }
        }
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<string> Get()
        {
            string Result = string.Empty;
            string instanceUrl = "https://dev277147.service-now.com/";
            string userName = "admin";
            string password = "dmdGS0R8q^A=";
            var tableName = "incident";
            var endpoint = $"/api/now/table/{tableName}";
            var url = instanceUrl + endpoint;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{userName}:{password}"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authToken);

                var content = new StringContent(JsonConvert.SerializeObject
                    (new Incident { ShortDescription="Sample VIkash Incident"}),Encoding.UTF8,"application/json");
                var response = await client.PostAsync(url,content);
                var jsonString = await response.Content.ReadAsStringAsync();
                Result = jsonString;


            }



            return Result;
        }
    }
}
