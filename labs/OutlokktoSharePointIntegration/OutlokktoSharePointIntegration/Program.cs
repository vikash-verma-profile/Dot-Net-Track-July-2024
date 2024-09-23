using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.Identity.Client;
using Microsoft.Graph;
using Azure.Identity;
using Azure.Core;
using Microsoft.Graph.Models;

namespace OutlokktoSharePointIntegration
{
    internal class Program
    {
        private static readonly string siteUrl = "https://ervikashverma.sharepoint.com/sites/SampleWebsite";
        private static readonly string tenantId = "3e1c602f-7880-45e7-b38e-b87855ef174d";
        private static readonly string clientId = "0008e470-c01b-441d-81b2-5a69aaf2b8c7";
        private static readonly string clientSecret = "LeR8Q~m0rrUDir4LXei58~7l9b9eqhboDKC4cdkM";
        private static readonly string resourceUrl = "https://ervikashverma.sharepoint.com";
        private static string siteId = "YOUR_SITE_ID";
        private static string listId = "YOUR_SITE_ID";
        private static readonly string redirectUri = "http://localhost";
        private static readonly string[] scopes = new[] { "Sites.Read.All" };
        static async Task Main(string[] args)
        {
            var accessToken = await GetAccessTokenAsync();
            siteId = await GetSiteIdByUrlAsync(accessToken, "ervikashverma.sharepoint.com", "sites/SampleWebsite");
            var scope = new[] { "https://graph.microsoft.com/.default" };
            var authProvider = new ClientSecretCredential(tenantId, clientId, clientSecret);
            var client = new GraphServiceClient(authProvider, scope);
            listId = await GetListIdByUrlAsync(siteId,client);
            Console.WriteLine(listId);
           
            await ReadInboxEmails(client, siteId, accessToken, listId);

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

        public static async Task<string> GetListIdByUrlAsync(string siteId, GraphServiceClient client)
        {
            var list = await client.Sites[siteId].Lists["Samplelist"].GetAsync();
            string listId = list.Id;
            return listId;
        }

        public static async Task ReadInboxEmails(GraphServiceClient client,string siteId, string accessToken,string listId)
        {
            var messages = await client.Users["VikashVerma@ervikashverma.onmicrosoft.com"].Messages.GetAsync();

            if (messages != null && messages.Value != null)
            {
                foreach (var item in messages.Value)
                {
                    var listItem = new ListItem
                    {
                        Fields = new FieldValueSet
                        {
                            AdditionalData = new Dictionary<string, object>
                            {
                                {"Title",item.Subject }
                            }
                        }
                    };

                    await client.Sites[siteId].Lists[listId].Items.PostAsync(listItem);
                }
            }
        }
    }
}
