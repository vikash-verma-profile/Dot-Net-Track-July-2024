// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Employee emp=new Employee();
Console.WriteLine("Please enter employee id");
emp.Id=Convert.ToInt32(Console.ReadLine());
emp.Name="Vikash";
Console.WriteLine($"employee details are : Employee Id {emp.Id} Employee Name: {emp.Name}" );