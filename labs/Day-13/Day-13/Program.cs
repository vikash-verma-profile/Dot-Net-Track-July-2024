using System.Xml;
using System.Xml.Serialization;

namespace Day_13
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public double Salary { get; set; }
    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            List<Employee> employeeList = new List<Employee>()
            { new Employee(){Id=101,Name="Anil",Gender="Male",Salary=100000},
                 new Employee(){Id=102,Name="Soniya",Gender="Female",Salary=200000},
                new Employee(){Id=103,Name="Rohit",Gender="Male",Salary=700000},
                new Employee(){Id=104,Name="Rakesh",Gender="Male",Salary=809000},
                 new Employee(){Id=105,Name="Vikash",Gender="Male",Salary=200009},
                new Employee(){Id=106,Name="Manju",Gender="Female",Salary=806409},
                new Employee(){Id=107,Name="Kapil",Gender="Male",Salary=110300},
                 new Employee(){Id=108,Name="Anil",Gender="Male",Salary=120210},
                new Employee(){Id=109,Name="Rocky",Gender="Male",Salary=150201},
            };

            //Employee emp = new Employee(){ Id = 102, Name = "Soniya", Gender = "Female", Salary = 200000 };
            //XmlSerializer x = new XmlSerializer(employeeList.GetType());
            //x.Serialize(Console.Out, employeeList);
            XmlWriter textWriter = 
                XmlWriter.Create("C:\\Users\\Level Up Solutions 1\\Desktop\\course-structure\\labs\\Day-13\\Day-13\\xmlfiles\\employeedata.xml");

            textWriter.WriteStartElement("employee");
            textWriter.WriteElementString("ID","12");
            textWriter.WriteElementString("Name", "Kapil");
            textWriter.WriteElementString("Gender", "Male");
            textWriter.WriteElementString("Salary", "150201");
            textWriter.WriteEndDocument();
            textWriter.Flush();
            textWriter.Close();

        }
    }
}
