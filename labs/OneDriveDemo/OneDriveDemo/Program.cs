using Microsoft.Identity.Client;

namespace OneDriveDemo
{
    public class Program
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

    }
}
