using Azure.Identity;
using Microsoft.Graph;

namespace OneDriveUpload
{
    internal class Program
    {
        private static readonly string tenantId = "3e1c602f-7880-45e7-b38e-b87855ef174d";
        private static readonly string clientId = "0008e470-c01b-441d-81b2-5a69aaf2b8c7";
        private static readonly string clientSecret = "LeR8Q~m0rrUDir4LXei58~7l9b9eqhboDKC4cdkM";
        private static readonly string userEmail = "VikashVerma@ervikashverma.onmicrosoft.com";
        private static readonly string recipentEmail = "arjun@ervikashverma.onmicrosoft.com";
        private static readonly string filePath = "OneDriveTest23.txt";
        static async Task Main(string[] args)
        {
            var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            var client = new GraphServiceClient(credential);
            var uplaodedFile=await UploadFileToDrive(client, filePath);
            await SendEmailNotification(client, uplaodedFile, recipentEmail);
        }

        private static async Task<DriveItem> UploadFileToDrive(GraphServiceClient client,string filePath)
        {
            var fileName = Path.GetFileName(filePath);
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var uploadSession = await client.Users[userEmail].Drive.Root.ItemWithPath(fileName).
                    CreateUploadSession().Request().PostAsync();

                var maxChunckSize = 320 * 1024;//320KB
                var chuckUploadProvider = new ChunkedUploadProvider(uploadSession,client,fileStream, maxChunckSize);
                var uploadedItem = await chuckUploadProvider.UploadAsync();
                Console.WriteLine($"File uploaded successfully ID: {uploadedItem.Id}");
                return uploadedItem;
            }
        }
        private static async Task SendEmailNotification(GraphServiceClient client, DriveItem uplaodedFile, string recipientEmail)
        {
            if (uplaodedFile != null)
            {
                var message = new Message
                {
                    Subject = "File Uplaoded to OneDrive",
                    Body = new ItemBody
                    {
                        ContentType=BodyType.Text,
                        Content = "The file has been successfully uploaded to oneDrive"
                    },
                    ToRecipients = new List<Recipient>
                        {
                             new Recipient
                            {
                                EmailAddress=new EmailAddress
                                {
                                    Address="er.vikashverma551@gmail.com"
                                },
                            }
                        }

                };
                await client.Users[userEmail].SendMail(message, null).Request().PostAsync();
                Console.WriteLine("Email sent to the person");

            }
        }
    }
}
