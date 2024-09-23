using Microsoft.Graph;
using Microsoft.Graph.Models;
using Newtonsoft.Json.Linq;
using Azure.Identity;



namespace DemoWithOutlookAaddin
{
    internal class Program
    {
        private static readonly string siteUrl = "https://levelupsolutionsin.sharepoint.com/sites/SampleWebsite";
        private static readonly string tenantId = "";
        private static readonly string clientId = "";
        private static readonly string clientSecret = "";
        private static readonly string resourceUrl = "https://levelupsolutionsin.sharepoint.com";
        static async Task Main(string[] args)
        {
            try
            {
                //Outlook.Application outlookApp = new Outlook.Application();
                //Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                //mailItem.Subject = "Test Email from C#";
                //mailItem.Body = "This is an automated email sent from c# application using outlook";
                //mailItem.To = "er.vikashverma551@gmail.com";
                //mailItem.Send();
                //Console.WriteLine("mail sent");

                //var token=GetAccessTokenAsync();
                var scope = new[] { "https://graph.microsoft.com/.default" };
                var authProvider = new ClientSecretCredential(tenantId,clientId,clientSecret);
                var client = new GraphServiceClient(authProvider, scope);
                //await sendEmail(client);
                //await CreateandSendMettingRquest(client);
                await ReadInboxEmails(client);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
          
        }

        public static async Task sendEmail(GraphServiceClient client)
        {
            var message = new Message
            {
                Subject="Test Email",
                Body = new ItemBody
                {
                    ContentType = BodyType.Text,
                    Content = "Hello This is automated email sent using Graph API"
                },
                ToRecipients = new List<Recipient>
                {
                    new Recipient
                    {
                        EmailAddress=new EmailAddress
                        {
                            Address="er.vikashverma551@gmail.com"
                        }
                    }
                }
            };
            Microsoft.Graph.Users.Item.SendMail.SendMailPostRequestBody body =
                new()
                {
                    Message = message,
                    SaveToSentItems = false
                };
            await client.Users["vikash@levelupsolutions.in"].SendMail.PostAsync(body);//(message,saveToSentItems:true).Request().PostAsnc();
            Console.WriteLine("Email sent");
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

        public static async Task CreateandSendMettingRquest(GraphServiceClient client)
        {
            var meeting = new Event
            {
                Subject = "Team Meeting",
                Body= new ItemBody
                {
                    ContentType=BodyType.Text,
                    Content="Please join us for team meeting"

                },
                Start=new DateTimeTimeZone
                {
                    DateTime = "2024-09-21T14:00:00",
                    TimeZone="UTC"
                },
                End = new DateTimeTimeZone
                {
                    DateTime = "2024-09-21T14:30:00",
                    TimeZone = "UTC"
                },
                Location =new Location
                {
                    DisplayName="Conference room 1"
                },
                Attendees=new List<Attendee>
                {
                    new Attendee
                    {
                        EmailAddress=new EmailAddress
                        {
                            Address="er.vikashverma551@gmail.com"
                        },
                        Type=AttendeeType.Required
                    }
                }
            };

            await client.Users["vikash@levelupsolutions.in"].Events.PostAsync(meeting);
        }
    
        public static async Task ReadInboxEmails(GraphServiceClient client)
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
