using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Day_5
{
    public class Employee
    {
        public int id;
        public string name;

       
    }
    internal class EmployeeProgram
    {
        public static Employee AddEmployee()
        {
            Employee e = new Employee();
            Console.WriteLine("Enter EmployeeID :");
            e.id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Name :");
            e.name = Console.ReadLine();
            return e;
        }
        public static void PrintData(Employee[] EmployeeList)
        {
            Console.WriteLine("ID | " + "Employee Name");
            for (int i = 0; i < EmployeeList.Length; i++)
            {
                if (EmployeeList[i] == null)
                {
                    break;
                }
                else
                {
                    Console.Write(EmployeeList[i].id +" "+ EmployeeList[i].name);
                }
                
            }
        }
        public static void Main2()
        {
           Employee[] employee =new Employee[10];
           int counter = 0;
           bool CircuitBreaker = true;
           while(CircuitBreaker)
           {
                Console.WriteLine("\n Please enter your choice \n 1.Add Employee \n 2.Update Employee \n 3.List Employee \n 4.Delete Employee \n 5.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        employee[counter] = AddEmployee();
                        counter++;
                        break;
                    case 3:
                        PrintData(employee);
                        break;
                    case 5:
                        CircuitBreaker = true;
                        break;
                    default:
                        Console.WriteLine("Please enter valid choice");
                        break;
                }
                if (!CircuitBreaker)
                {
                    break;
                }
            }
           
        }
    }
}
