namespace Day_4
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            string Number = "12";
            //int ParsedNumber=int.Parse(Number);
            bool Isint  = int.TryParse(Number,out int ParsedNumber);
            if (Isint)
            {
                Console.WriteLine("You parse NUmber is : " + ParsedNumber);
            }
            else
            {
                Console.WriteLine("its not a number");
            }
          

        }
    }
}
