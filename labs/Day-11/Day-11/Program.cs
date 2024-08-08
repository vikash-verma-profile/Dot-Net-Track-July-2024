using System.Text.RegularExpressions;

namespace Day_11
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            string pattern = "^[0-9]{4}$";
            Regex rex = new Regex(pattern);
            string x = "1234";
            if (rex.IsMatch(x))
            {
                Console.WriteLine("its a number");
            }
            else
            {
                Console.WriteLine("its not a number");

            }
           
        }
    }
}
