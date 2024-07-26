namespace Day_5
{

    class Student
    {
        public int Id;
        public string StudentName;
        public string StudentEmail;

        public Student(int id,string Name)
        {
            Id= id;
            StudentName= Name;
        }
        public void PrintStudentData()
        {
            Console.Write(StudentName);
            Console.Write(Id);
        }
    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            Student student = new Student(1,"Vikash");
            student.PrintStudentData();
        }
    }
}
