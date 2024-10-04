using Azure.Identity;
using Microsoft.Graph;

namespace SendMessageToTeamsChannel
{
    internal class Program
    {
        private static readonly string tenantId = "3e1c602f-7880-45e7-b38e-b87855ef174d";
        private static readonly string clientId = "0008e470-c01b-441d-81b2-5a69aaf2b8c7";
        private static readonly string clientSecret = "LeR8Q~m0rrUDir4LXei58~7l9b9eqhboDKC4cdkM";
        private static readonly string userEmail = "VikashVerma@ervikashverma.onmicrosoft.com";
        static async Task Main(string[] args)
        {
            string teamId = "";
            var credential = new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions
            { TenantId=tenantId,
            ClientId=clientId,
            });
            var client = new GraphServiceClient(credential);
            var teams = await client.Users["VikashVerma@ervikashverma.onmicrosoft.com"].JoinedTeams.Request().GetAsync();
            foreach (var item in teams)
            {
                //Console.WriteLine($"Team Name : {item.DisplayName} , Team Id : {item.Id}");
                teamId = item.Id;
                break;
            }
            //create a channel

           var channel= await CreateChannel(client,teamId,"Vikash Channel Test","Description of channel is Test");

            if (channel != null)
            {
                await SendMessage(client, teamId,channel.Id,"Hello, Team !! This is a test message from Vikash ");
            }
            Console.WriteLine("Message was sent successfully");
        }

        private static async Task<Channel> CreateChannel(GraphServiceClient client,string teamid,string channelName,string channelDescription)
        {
            var channel = new Channel
            {
                DisplayName = channelName,
                Description = channelDescription,
                MembershipType = ChannelMembershipType.Standard
            };
            return await client.Teams[teamid].Channels.Request().AddAsync(channel);
        }
        private static async Task SendMessage(GraphServiceClient client, string teamid,string channelId,string messageContent)
        {
            var chatMessage = new ChatMessage
            {
                Body=new ItemBody
                {
                    Content=messageContent
                }
            };
            await client.Teams[teamid].Channels[channelId].Messages.Request().AddAsync(chatMessage);
        }
    }
}
