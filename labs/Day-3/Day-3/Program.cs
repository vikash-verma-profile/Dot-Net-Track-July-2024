namespace Day_3
{
    internal class Program
    {
        public static void swap(int a,int b)
        {
            int c = a;
            a= b;
            b = c;      
            Console.WriteLine("Value of a and b is a= "+a+"b= "+b);
        }
        static void Main(string[] args)
        {
            int a = 1, b = 2;
            Console.WriteLine("Value of numbers a= "+a+"b= "+b);
            swap(a, b);
            Console.WriteLine("Value of numbers after swap a= " + a + "b= " + b);
        }
    }
}
