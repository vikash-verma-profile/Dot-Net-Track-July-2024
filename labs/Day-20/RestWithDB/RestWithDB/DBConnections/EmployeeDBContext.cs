using System.Data.SqlClient;

namespace RestWithDB.DBConnections
{
    public class EmployeeDBContext
    {
        SqlConnection _connection;

        public EmployeeDBContext()
        {
            _connection = new
           SqlConnection("Data Source=DESKTOP-HVUT504;Initial Catalog=EmployeeDB;Integrated Security=True;");
        }
        public SqlDataReader GetData(string query)
        {
            SqlCommand cmd = new SqlCommand(query, _connection);
            _connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        public void CloseConnection()
        {
            _connection.Close();
        }
        ~ EmployeeDBContext()
        {
            _connection.Close();
        }

    }
}
