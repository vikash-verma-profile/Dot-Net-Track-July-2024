using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11
{

    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public double Salary { get; set; }
        public int DeptId { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
    }
    internal class DemoWithEmployee
    {
        public static void Main()
        {
            List<Employee> employeeList = new List<Employee>();
            employeeList.Add(new Employee() { Id="EMP1",Name="Vikash Verma",Salary =80000,DeptId=1});
            employeeList.Add(new Employee() { Id = "EMP2", Name = "John Carry", Salary = 90000, DeptId = 1 });
            employeeList.Add(new Employee() { Id = "EMP3", Name = "Sumit Dadwal", Salary = 10000, DeptId = 2 });
            employeeList.Add(new Employee() { Id = "EMP4", Name = "Rohit Sharma", Salary = 40000, DeptId = 3 });
            employeeList.Add(new Employee() { Id = "EMP5", Name = "Kapil Verma", Salary = 50000, DeptId = 1 });
            List<Department> departmentList = new List<Department>();
            departmentList.Add(new Department { Id=1,DepartmentName="IT"});
            departmentList.Add(new Department { Id = 2, DepartmentName = "Admin" });
            departmentList.Add(new Department { Id = 3, DepartmentName = "Sales" });
            departmentList.Add(new Department { Id = 4, DepartmentName = "Security" });

            //var result = from employee in employeeList where employee.Salary >10000 select employee;
            var result = (from employee in employeeList join dept in departmentList
                         on employee.DeptId equals dept.Id 
                          select new { ID=employee.Id,Name=employee.Name,
                          DepartmentName=dept.DepartmentName
                          }).ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item.ID+" | "+item.Name +" | "+item.DepartmentName);
            }

        }
    }
}
