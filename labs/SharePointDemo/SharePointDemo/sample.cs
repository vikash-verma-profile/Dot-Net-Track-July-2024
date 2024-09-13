using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace SharePointDemo
{
    public class sample
    {
        static async Task Main2(string[] args)
        {
            // Set the values for your application
            string clientId = "";
            string clientSecret = "";
            string tenantId = "";
            string[] scopes = new string[] { "https://graph.microsoft.com/.default" };

            try
            {

                IConfidentialClientApplication app = ConfidentialClientApplicationBuilder
                    .Create(clientId)
                    .WithClientSecret(clientSecret)
                    .WithAuthority(new Uri($"https://login.microsoftonline.com/{tenantId}"))
                    .Build();

                // Acquire an access token for the client
                AuthenticationResult result = await app.AcquireTokenForClient(scopes)
                    .ExecuteAsync();

                string accessToken = result.AccessToken;

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    var response = await httpClient.GetAsync("https://graph.microsoft.com/v1.0/sites?search=*");

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON response
                        //JSObject json = JSObject.Parse(content);

                        //// Extract the value of the "name" property for each site
                        //foreach (var site in json["value"])
                        //{
                        //    Console.WriteLine(site["name"]);
                        //}
                    }
                    else
                    {
                        Console.WriteLine($"Failed to call Microsoft Graph API: {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
