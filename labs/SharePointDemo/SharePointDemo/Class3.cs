using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SharePointDemo
{
    public class Class3
    {
        private static readonly string tenantId = "";
        private static readonly string clientId = "";
        private static readonly string clientSecret = "";
        private static readonly string graphApiEndpoint = "https://graph.microsoft.com/v1.0/";
        private static readonly string redirectUri = "http://localhost"; // Ensure this matches your Azure AD app registration
        private static readonly string[] scopes = new[] { "Sites.Read.All" };

        static async Task Main4(string[] args)
        {
            try
            {
                // Step 1: Get Access Token
                var accessToken = await GetAccessTokenAsync();
                Console.WriteLine($"Access Token: {accessToken}");

                // Step 2: Use Access Token to Call Graph API to Get SharePoint Sites
                var sites = await GetSharePointSitesAsync(accessToken);
                Console.WriteLine($"SharePoint Sites: {sites}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static async Task<string> GetAccessTokenAsync()
        {
            // Create a PublicClientApplication instance
            var app = PublicClientApplicationBuilder.Create(clientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, tenantId)
                .WithRedirectUri(redirectUri)
                .Build();

            // Acquire Token interactively
            var result = await app.AcquireTokenInteractive(scopes)
                .ExecuteAsync();

            return result.AccessToken;
        }

        public static async Task<string> GetSharePointSitesAsync(string accessToken)
        {
            var sitesEndpoint = "https://graph.microsoft.com/v1.0/sites?search=*"; // Use the appropriate endpoint for searching sites

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await httpClient.GetAsync(sitesEndpoint);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return responseContent;
                }
                else
                {
                    throw new Exception($"Failed to retrieve SharePoint sites. Status code: {response.StatusCode}, Response: {responseContent}");
                }
            }
        }
    }
}
