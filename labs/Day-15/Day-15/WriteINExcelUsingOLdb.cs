using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_15
{
    internal class WriteINExcelUsingOLdb
    {
        public static void Main()
        {
            string excelFilePath = @"Book1.xlsx";
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFilePath};Extended Properties='Excel 12.0 Xml;HDR=YES;'";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE [Sheet1$] SET NAME='RAKESH SHARMA' WHERE ID='123';";
                //string insertQuery = "INSERT INTO [Sheet1$] (ID, Name) VALUES ('123', 'Vikash Verma')";
                using (OleDbCommand com = new OleDbCommand(updateQuery, connection))
                {
                    int rowAffected = com.ExecuteNonQuery();
                    Console.WriteLine("Data inserted successfully.");
                }
            }
        }
    }
}
