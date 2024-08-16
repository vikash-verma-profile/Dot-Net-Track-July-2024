using Newtonsoft.Json;

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

        public static List<Employee> ReadData(string fileName)
        {
           var jsonString= File.ReadAllText(fileName);
            //var employee = JsonSerializer.Deserialize<Employee>(jsonString);
            var employee = JsonConvert.DeserializeObject<List<Employee>>(jsonString);
            return employee;
        }


    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            var employee = new Employee()
            {
                EmpID = "EMP123",
                ID = 123,
                Gender = "Male",
                Name = "Vikash Verma",
                Salary = 9090
            };

            List<Employee> employeesList=new List<Employee> { employee,new Employee {
             EmpID = "EMP124",
                ID = 124,
                Gender = "Male",
                Name = "Rahul Sharma",
                Salary = 10000} };
            //string jsonString=JsonSerializer.Serialize(employee);
            string jsonString = JsonConvert.SerializeObject(employeesList);
            string fileName = "employeelist.json";

            Employee.WriteData(fileName, jsonString);
            var EmployeeData= Employee.ReadData(fileName);

            foreach (var item in EmployeeData)
            {
                Console.WriteLine("Employee Data: " + item.Name);
            }
          


            
        }
    }
}
