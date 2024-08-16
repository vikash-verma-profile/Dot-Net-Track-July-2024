using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_15
{
    internal class OLEDBConnectionDEMO
    {
        static void Main(string[] args)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Book1.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=Yes;IMEX=1\";";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM [Sheet1$]";
                using (OleDbCommand command=new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader=command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader[0].ToString()+" | "+ reader[1].ToString());
                        }
                    }
                }
            }
        
        }
    }
}
