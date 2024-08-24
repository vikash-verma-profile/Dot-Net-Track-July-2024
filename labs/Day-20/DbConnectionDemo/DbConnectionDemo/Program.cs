using System.Data.SqlClient;

namespace DbConnectionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new 
                SqlConnection("Data Source=DESKTOP-HVUT504;Initial Catalog=EmployeeDB;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("select * from tblEmployee",con);
            con.Open();
            SqlDataReader rdr=cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr["id"]+" | " + rdr["EmployeeName"]);
            }
        }
    }
}
