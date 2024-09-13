using Microsoft.Identity.Client;
using Microsoft.SharePoint.Client;
using System;
using System.Threading.Tasks;

class Program
{
    private static async Task Main1(string[] args)
    {
        // Replace these values with your Azure AD app registration details
        var tenantId = "163d48cb-7075-46be-9b05-d4af525c267f";  // Tenant ID (Directory ID)
        var clientId = "3c35121b-67ec-4fc6-939c-2652e793cd83";  // Application (client) ID
        var clientSecret = "ixY8Q~UdIyu17g.ctJ~EmhrJSUKSflqesf.2naZm"; // Client secret
        var siteUrl = "https://levelupsolutionsin.sharepoint.com/sites/SampleWebsite/"; // SharePoint Site URL

        // Create the MSAL client
        var app = ConfidentialClientApplicationBuilder.Create(clientId)
            .WithClientSecret(clientSecret)
            .WithAuthority(new Uri($"https://login.microsoftonline.com/{tenantId}"))
            .Build();

        // Acquire token
        var authResult = await app.AcquireTokenForClient(new[] { "https://levelupsolutionsin.sharepoint.com/.default" })
                                  .ExecuteAsync();

        string accessToken = authResult.AccessToken;

        // Connect to SharePoint
        using (var context = new ClientContext(siteUrl))
        {
            context.ExecutingWebRequest += (sender, e) =>
            {
                e.WebRequestExecutor.RequestHeaders["Authorization"] = "Bearer " + accessToken;
            };

            // Example: Load the web and print the title
            Web web = context.Web;
            context.Load(web);
            await context.ExecuteQueryAsync();

            Console.WriteLine($"Site Title: {web.Title}");
        }
    }
}
