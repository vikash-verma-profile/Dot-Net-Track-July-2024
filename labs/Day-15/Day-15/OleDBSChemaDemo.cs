using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_15
{
    internal class OleDBSChemaDemo
    {
        public static void Main1()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Book1.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=Yes;IMEX=1\";";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM [Sheet1$]";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {


                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt != null)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            string colName = col.ColumnName;
                            Console.WriteLine(colName + "\t");
                        }
                    }


                }
            }
        }
    }
}
