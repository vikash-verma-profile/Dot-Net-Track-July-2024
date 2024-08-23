using Box.V2;
using Box.V2.Config;
using Box.V2.JWTAuth;
using Box.V2.Models;
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
        public async Task<List<BoxItem>> Get()
        {
            //try
            //{
                string clientId = "uzc2qa40kji5fz7wykcto14f0e3tanv9";
                string clientSecret = "woQei6eLHnDnuBOxJf6ayStd064mOKCC";
                string developerToken = "DnS3BR1rYDd2VqGpT11QKsxha6jNHBIS";

                var boxConfig = new BoxConfig(clientId, clientSecret, new Uri("http://localhost"));
                var boxJWTAuth = new BoxJWTAuth(boxConfig);

                var boxClient = boxJWTAuth.AdminClient(developerToken);
               

                var user = await boxClient.UsersManager.GetCurrentUserInformationAsync();

                var items = await boxClient.FoldersManager.GetFolderItemsAsync("0", 100);


                //foreach (var item in items.Entries)
                //{

                //}
                //return user.Name;
                return items.Entries;
            //}
            //catch (Exception ex)
            //{
            //    return new List<dynamic>(); ;
            //}
          
        }
    }
}
