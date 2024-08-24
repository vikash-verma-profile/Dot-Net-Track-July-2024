using System.Data.SqlClient;

namespace DbConnectionDemo
{
    internal class Program
    {

        public static SqlConnection CreateConnection()
        {
            SqlConnection con = new
                SqlConnection("Data Source=DESKTOP-HVUT504;Initial Catalog=EmployeeDB;Integrated Security=True;");
            return con;
        }

        public static void GetData(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("select * from tblEmployee", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr["id"] + " | " + rdr["EmployeeName"]);
            }
            con.Close();
        }

        public static void InsertData(string EmployeeName,SqlConnection con)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand($"insert into tblEmployee(EmployeeName) Values('{EmployeeName}')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateData(int EmployeeId,string EmployeeName, SqlConnection con)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand($"update tblEmployee set EmployeeName ='{EmployeeName}' where Id={EmployeeId}", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void DeleteData(int EmployeeId,SqlConnection con)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand($"Delete tblEmployee  where Id={EmployeeId}", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        static void Main(string[] args)
        {
            SqlConnection conn = CreateConnection();
            bool isLoopRunning = true;
            while (isLoopRunning)
            {
                Console.WriteLine("Please enter a choice");
            Console.WriteLine("enter the operation you want to perform \n 1. List Employees" +
                "\n 2. Insert Employee \n 3.Update Employee \n 4.Delete Employee \n 5.Exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            CreateConnection();
           
                switch (choice)
                {
                    case 1:
                        GetData(conn);
                        break;
                    case 2:
                        Console.WriteLine("Please enter employee Name");
                        string employeeName = Console.ReadLine();
                        InsertData(employeeName, conn);
                        Console.WriteLine("Your record is being added successfully !");
                        break;
                    case 3:
                        Console.WriteLine("Please enter employee ID");
                        int employeeID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please enter new employee Name");
                        string newEmployeeName = Console.ReadLine();
                        UpdateData(employeeID, newEmployeeName, conn);
                        Console.WriteLine("Your record is being updated successfully !");
                        break;
                    case 4:
                        Console.WriteLine("Please enter employee ID");
                        int deleteEmployeeID = Convert.ToInt32(Console.ReadLine());
                        DeleteData(deleteEmployeeID, conn);
                        Console.WriteLine("Your record is being deleted successfully !");
                        break;
                    case 5:
                        isLoopRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter correct choice");
                        break;
                }
            }
        }
    }
}
