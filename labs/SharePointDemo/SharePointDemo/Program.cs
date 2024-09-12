using Microsoft.Extensions.DependencyInjection;
using Microsoft.SharePoint.Client;
using Microsoft.Win32.SafeHandles;
using PnP.Core.Auth;
using PnP.Core.Services;
using System.Security;

namespace SharePointDemo
{
    internal class Program
    {
        public static void ConfigurePnpServices(IServiceCollection services,string username,SecureString password)
        {
            services.AddPnPContextFactory(options =>
            {
                options.DefaultAuthenticationProvider = new UsernamePasswordAuthenticationProvider("","", username, password);
            });
        }
        static async Task Main(string[] args)
        {
            string siteUrl = "https://levelupsolutionsin.sharepoint.com/sites/SampleWebsite";
            string username = "Akash@levelupsolutions.in";
            string password = "RGupta#20080";
            System.Security.SecureString securePassword = new System.Security.SecureString();
            foreach (var item in password)
            {
                securePassword.AppendChar(item);
            }

            var serviceCollections = new ServiceCollection();
            ConfigurePnpServices(serviceCollections, username, securePassword);
            var serviceProvider = serviceCollections.BuildServiceProvider();
            var pnpContextFactory = serviceProvider.GetRequiredService<IPnPContextFactory>();
            using (var context = await pnpContextFactory.CreateAsync(new Uri(siteUrl)))
            {
                await context.Web.LoadAsync(p=>p.Title);
                Console.WriteLine(context.Web.Title);
            }
        }
    }
}
