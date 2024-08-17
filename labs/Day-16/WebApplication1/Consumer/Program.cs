using System.Text;
using System.Text.Json;

namespace Consumer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string endpoint = "https://localhost:7181/api/v1.0/Employee";
            using var httpclient = new HttpClient();
            var employee = new
            {
                id = 1234,
                name = "Vikash Verma",
                gender = "Male",
                salary = 10000
            };
            var jsonContent=JsonSerializer.Serialize(employee);
            var content= new StringContent(jsonContent,Encoding.UTF8,"application/json");
            var response= await httpclient.PostAsync(endpoint, content);
            var responseData = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(responseData);
            Thread.Sleep(5000);
            var getResponse = await httpclient.GetAsync("https://localhost:7181/api/v1.0/Employee/get-employees");
            var getResponseData = getResponse.Content.ReadAsStringAsync();
            Console.WriteLine(getResponseData.Result);
        }
    }
}
