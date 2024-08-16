using System.Text.Json;

namespace Day_15
{
    public class Employee
    {
        public string EmpID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }

        public static void WriteData(string fileName,string jsonString)
        {
            File.WriteAllText(fileName, jsonString);
        }

        public static Employee ReadData(string fileName)
        {
           var jsonString= File.ReadAllText(fileName);
            var employee = JsonSerializer.Deserialize<Employee>(jsonString);
            return employee;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee()
            {
                EmpID = "EMP123",
                ID = 123,
                Gender = "Male",
                Name = "Vikash Verma",
                Salary = 9090
            };

            string jsonString=JsonSerializer.Serialize(employee);
            string fileName = "employee.json";

            Employee.WriteData(fileName, jsonString);
            var EmployeeData= Employee.ReadData(fileName);
            Console.WriteLine("Employee Data: "+EmployeeData.Name);


            
        }
    }
}
