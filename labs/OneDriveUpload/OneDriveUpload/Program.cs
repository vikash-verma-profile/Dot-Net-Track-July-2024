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
            //var uplaodedFile = await UploadFileToDrive(client, filePath);
            //await SendEmailNotification(client, uplaodedFile, recipentEmail);
            await ListFilesInDrive(client, userEmail);
        }

        private static async Task<DriveItem> UploadFileToDrive(GraphServiceClient client, string filePath)
        {
            var fileName = Path.GetFileName(filePath);
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var uploadSession = await client.Users[userEmail].Drive.Root.ItemWithPath(fileName).
                    CreateUploadSession().Request().PostAsync();

                var maxChunckSize = 320 * 1024;//320KB
                var chuckUploadProvider = new ChunkedUploadProvider(uploadSession, client, fileStream, maxChunckSize);
                var uploadedItem = await chuckUploadProvider.UploadAsync();
                Console.WriteLine($"File uploaded successfully ID: {uploadedItem.Id}");
                return uploadedItem;
            }
        }
        private static async Task SendEmailNotification(GraphServiceClient client, DriveItem uploadedFile, string recipientEmail)
        {
            if (uploadedFile != null)
            {
                var message = new Message
                {
                    Subject = "File Uploaded to OneDrive",
                    Body = new ItemBody
                    {
                        ContentType = BodyType.Text,
                        Content = "The file has been successfully uploaded to OneDrive."
                    },
                    ToRecipients = new List<Recipient>
            {
                new Recipient
                {
                    EmailAddress = new EmailAddress
                    {
                        Address = recipientEmail
                    }
                }
            }
                };

                try
                {
                    await client.Users[userEmail].SendMail(message, null).Request().PostAsync();
                    Console.WriteLine("Email sent to the recipient successfully.");
                }
                catch (ServiceException ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                    // Log or handle the specific error code (e.g., 550) for further action
                }
            }
        }
            
        private static async Task ListFilesInDrive(GraphServiceClient client,string userEmail)
        {
            var driveItems = await client.Users[userEmail].Drive.Root.Children.Request().GetAsync();

            foreach (var driveItem in driveItems)
            {
                Console.WriteLine($"- {driveItem.Name} (Id :{driveItem.Id})");
            }
        }
    
    }
}
