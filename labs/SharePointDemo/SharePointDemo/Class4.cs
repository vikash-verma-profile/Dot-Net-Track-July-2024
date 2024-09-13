using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SharePointDemo
{
    internal class Class4
    {// Application (Client) ID and Tenant ID from Azure AD App Registration
        private static readonly string tenantId = "";
        private static readonly string clientId = "";
        private static readonly string clientSecret = "";
        private static readonly string graphApiEndpoint = "https://graph.microsoft.com/v1.0/";
        private static readonly string redirectUri = "http://localhost"; // Ensure this matches your Azure AD app registration
        private static readonly string[] scopes = new[] { "Sites.Read.All" };

        // SharePoint Site ID or URL
        private static  string siteId = "YOUR_SITE_ID"; // Replace with your SharePoint site ID

        static async Task Main5(string[] args)
        {
            try
            {
                // Step 1: Get Access Token
                var accessToken = await GetAccessTokenAsync();
                Console.WriteLine($"Access Token: {accessToken}");

                siteId = await GetSiteIdByUrlAsync(accessToken, "levelupsolutionsin.sharepoint.com","sites/SampleWebsite");
                // Step 2: Use Access Token to Call Graph API to Get SharePoint Site Title
                var siteTitle = await GetSiteTitleAsync(accessToken, siteId);
                Console.WriteLine($"Site Title: {siteTitle}");
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

        public static async Task<string> GetSiteTitleAsync(string accessToken, string siteId)
        {
            var siteEndpoint = $"https://graph.microsoft.com/v1.0/sites/{siteId}";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await httpClient.GetAsync(siteEndpoint);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // Parse the title from the response content
                    var siteData = Newtonsoft.Json.Linq.JObject.Parse(responseContent);
                    return siteData["name"]?.ToString(); // Title of the site
                }
                else
                {
                    throw new Exception($"Failed to retrieve site title. Status code: {response.StatusCode}, Response: {responseContent}");
                }
            }
        }
        public static async Task<string> GetSiteIdByUrlAsync(string accessToken, string hostname, string sitePath)
        {
            var siteEndpoint = $"https://graph.microsoft.com/v1.0/sites/{hostname}:/{sitePath}";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await httpClient.GetAsync(siteEndpoint);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var siteData = Newtonsoft.Json.Linq.JObject.Parse(responseContent);
                    return siteData["id"]?.ToString(); // Site ID
                }
                else
                {
                    throw new Exception($"Failed to retrieve site ID. Status code: {response.StatusCode}, Response: {responseContent}");
                }
            }
        }
    }
}
