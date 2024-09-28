using Azure.Identity;
using Microsoft.Graph;
using System.Text.Json;

namespace WriteExcelWithOneDrive
{
    internal class Program
    {
        private static readonly string tenantId = "3e1c602f-7880-45e7-b38e-b87855ef174d";
        private static readonly string clientId = "0008e470-c01b-441d-81b2-5a69aaf2b8c7";
        private static readonly string clientSecret = "LeR8Q~m0rrUDir4LXei58~7l9b9eqhboDKC4cdkM";
        private static readonly string userEmail = "VikashVerma@ervikashverma.onmicrosoft.com";
        private static readonly string workSheetName = "Sheet1";
        private static readonly string rangeAddress = "A1:C4";
        static async Task Main(string[] args)
        {
            var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            var client = new GraphServiceClient(credential);

            //Retereve the user's oneDrive root

            var drive = await client.Users[userEmail].Drive.Request().GetAsync();

            if(drive != null)
            {
                var driveItems = await client.Users[userEmail].Drive.Root.Children.Request().GetAsync();

                //find your excel file
                var excelFile = driveItems.FirstOrDefault(x => x.Name == "SampleFile.xlsx");
                if (excelFile != null)
                {
                    var dataToWrite = new List<List<Object>>
                    {
                        new List<object>{"Name","Age","Country"},
                         new List<object>{"Vikash Verma","42","India"},
                          new List<object>{"Sumesh Sharama","32","India"},
                          new List<object>{"John","32","USA"},
                    };
                    await WriteExcelData(client,drive.Id,excelFile.Id,workSheetName,rangeAddress,dataToWrite);
                }
            }
        }

        public static async Task WriteExcelData(GraphServiceClient client,string driveID,string ID,string worksheetName,string rangeAddress, List<List<Object>> dataToWrite)
        {
            string jsonString=JsonSerializer.Serialize(dataToWrite);
            JsonDocument jsonDoc=JsonDocument.Parse(jsonString);
            var workbookRange = new WorkbookRange
            {
                Values = jsonDoc
            };
            await client.Users[userEmail].Drive.Items[ID].Workbook.Worksheets[worksheetName]
                .Range(rangeAddress).Request().PatchAsync(workbookRange);

            Console.WriteLine("Data written successfully");
        }
    }
}
