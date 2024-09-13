using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace SharePointDemo
{
    internal class Class2
    {
        private static readonly string tenantId = "163d48cb-7075-46be-9b05-d4af525c267f";
        private static readonly string clientId = "3c35121b-67ec-4fc6-939c-2652e793cd83";
        private static readonly string clientSecret = "ixY8Q~UdIyu17g.ctJ~EmhrJSUKSflqesf.2naZm";
        private static readonly string graphApiEndpoint = "https://graph.microsoft.com/v1.0/";
        private static readonly string[] scopes = new[] { "User.Read" };
        static async Task Main(string[] args)
        {
            try
            {
                var accessToken = await GetAccessTokenAsync();
                Console.WriteLine($"Access Token: {accessToken}");

                // Example: Get user details
                var userDetails = await GetUserDetailsAsync(accessToken);
                Console.WriteLine($"User Details: {userDetails}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static async Task<string> GetAccessTokenAsync()
        {
            var app = PublicClientApplicationBuilder.Create(clientId)
        .WithAuthority(AzureCloudInstance.AzurePublic, tenantId)
            .WithRedirectUri("http://localhost")
        .Build();

            var result = await app.AcquireTokenInteractive(scopes)
                .ExecuteAsync();

            // Inspect token claims here if needed
            var token = result.AccessToken;
            Console.WriteLine($"Access Token: {token}");
            return token;
        }

        public static async Task<string> GetUserDetailsAsync(string accessToken)
        {
            var userEndpoint = $"{graphApiEndpoint}me"; // Change the endpoint as needed

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await httpClient.GetAsync(userEndpoint);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return responseContent;
                }
                else
                {
                    throw new Exception($"Failed to retrieve user details. Status code: {response.StatusCode}, Response: {responseContent}");
                }
            }
        }
    }
}
