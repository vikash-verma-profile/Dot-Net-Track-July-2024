using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_12
{
    class StudentDemo
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentCourseId { get; set; }
    }
    class Course
    {
        public int ID { get; set; }
        public string CourseName { get; set; }
    }
    internal class Student
    {
        public static void Main2()
        {
           IList<StudentDemo> students = new List<StudentDemo>()
           {
               new StudentDemo(){StudentId=1,StudentName="John",StudentCourseId=1},
               new StudentDemo(){StudentId=2,StudentName="Bill",StudentCourseId=2},
               new StudentDemo(){StudentId=3,StudentName="Ram",StudentCourseId=1},
           };
            IList<Course> courseList = new List<Course>() { 
            new Course(){ID=1,CourseName="Course 1"},
            new Course(){ID=2,CourseName="Course 2"},
            new Course(){ID=3,CourseName="Course 3"},
            };

            var groupJoin = courseList.GroupJoin(students, std => std.ID, s => s.StudentCourseId,
                (std, studentGroup) => new { Students = studentGroup, CourseFullName = std.CourseName });

            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.CourseFullName);
                foreach (var stud in item.Students)
                {
                    Console.WriteLine(stud.StudentName);
                }
            }
        
        }
    }
}
