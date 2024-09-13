using Microsoft.Online.SharePoint.TenantAdministration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharePointDemo
{
    internal class Class1
    {
        private static readonly string siteUrl = "https://levelupsolutionsin.sharepoint.com/sites/SampleWebsite";
        private static readonly string tenantId = "";
        private static readonly string clientId = "";
        private static readonly string clientSecret = "";
        private static readonly string resourceUrl = "https://levelupsolutionsin.sharepoint.com";

        static async Task Main3(string[] args)
        {
            try
            {
                var accessToken = await GetAccessTokenAsync();
                Console.WriteLine($"Access Token: {accessToken}");

                // Use the access token to access SharePoint data
                var siteTitle = await GetSiteTitleAsync(accessToken);
                Console.WriteLine($"Site Title: {siteTitle}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static async Task<string> GetAccessTokenAsync()
        {
            var tokenEndpoint = $"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token";

            using (var httpClient = new HttpClient())
            {
                var requestContent = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "client_id", clientId },
                { "client_secret", clientSecret },
                { "scope", $"{resourceUrl}/.default" }
            });

                var response = await httpClient.PostAsync(tokenEndpoint, requestContent);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var json = JObject.Parse(responseContent);
                    var accessToken = json["access_token"]?.ToString();
                    return accessToken;
                }
                else
                {
                    throw new Exception($"Failed to obtain access token. Status code: {response.StatusCode}, Response: {responseContent}");
                }
            }
        }

        public static async Task<string> GetSiteTitleAsync(string accessToken)
        {
            var siteUrl = "https://levelupsolutionsin.sharepoint.com/sites/SampleWebsite/_api/web/title";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await httpClient.GetAsync(siteUrl);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var json = JObject.Parse(responseContent);
                    var title = json["Title"]?.ToString();
                    return title;
                }
                else
                {
                    throw new Exception($"Failed to retrieve site title. Status code: {response.StatusCode}, Response: {responseContent}");
                }
            }
        }
    }
}