using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_9
{
    class Employee
    {
        public int EmpId { get; set; }
        public double EmpSalary { get; set; }
        public string Name { get; set; }

        public void GetData()
        {
            Console.WriteLine("Please enter Employee Id");
            EmpId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter Employee Name");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter Employee Salary");
            EmpSalary = Convert.ToDouble(Console.ReadLine());
        }
    }
    internal class GenericCOllections
    {
        public static void Main3()
        {
            //List<int> myList=new List<int>();
            //for (int i = 0; i < 10; i++) {
            //    myList.Add(i);  
            //}

            //foreach (var item in myList)
            //{
            //    Console.WriteLine(item);
            //}

            List<Employee> emplist=new List<Employee>();
            for (int i = 0; i < 2; i++)
            {
                Employee obj = new Employee();
                obj.GetData();
                emplist.Add(obj);
            }
            foreach (var item in emplist)
            {
                Console.WriteLine("Employee ID" + item.EmpId);
                Console.WriteLine("Employee Name" + item.Name);
                Console.WriteLine("Employee Salary" + item.EmpSalary);
            }
            
        }
    }
}
