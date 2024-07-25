using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4
{
    class Student
    {
        //fields
        public int RollNo;
        public string Name;
        public string StudentClass;
        public string Gender;
        //Methods
        public void PrintData(Student student)
        {
            Console.WriteLine("Student Details are :");
            Console.WriteLine(student.Name);
            Console.WriteLine(student.StudentClass);
            Console.WriteLine(student.RollNo);
            Console.WriteLine(student.Gender);
        }
    }
    internal class Classesdemo
    {
        public static void Main()
        {
            Student student = new Student();
            student.Name = "Vikash Verma";
            student.StudentClass = "X";
            student.RollNo = 101;
            student.Gender = "Male";
            student.PrintData(student);


        }
    }
}
