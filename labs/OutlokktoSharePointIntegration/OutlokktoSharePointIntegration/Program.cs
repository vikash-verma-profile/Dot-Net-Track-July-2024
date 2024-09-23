using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.Identity.Client;
using Microsoft.Graph;
using Azure.Identity;
using Azure.Core;

namespace OutlokktoSharePointIntegration
{
    internal class Program
    {
        private static readonly string siteUrl = "https://levelupsolutionsin.sharepoint.com/sites/SampleWebsite";
        private static readonly string tenantId = "";
        private static readonly string clientId = "";
        private static readonly string clientSecret = "";
        private static readonly string resourceUrl = "https://levelupsolutionsin.sharepoint.com";
        private static string siteId = "YOUR_SITE_ID";
        private static readonly string redirectUri = "http://localhost";
        private static readonly string[] scopes = new[] { "Sites.Read.All" };
        static async Task Main(string[] args)
        {
            var accessToken = await GetAccessTokenAsync();
            siteId = await GetSiteIdByUrlAsync(accessToken, "levelupsolutionsin.sharepoint.com", "sites/SampleWebsite");
            //Console.WriteLine(siteId);
            var scope = new[] { "https://graph.microsoft.com/.default" };
            var authProvider = new ClientSecretCredential(tenantId, clientId, clientSecret);
            var client = new GraphServiceClient(authProvider, scope);
            await ReadInboxEmails(client, siteId, accessToken);

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

        public static async Task ReadInboxEmails(GraphServiceClient client,string siteId, string accessToken)
        {
            var messages = await client.Users["akash@levelupsolutions.in"].Messages.GetAsync();

            if (messages != null && messages.Value != null)
            {
                foreach (var item in messages.Value)
                {
                    Console.WriteLine(item.Subject);
                }
            }
        }
    }
}
