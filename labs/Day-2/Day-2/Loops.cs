

namespace Day_2
{
    internal class Loops
    {
        static void Main3(string[] args)
        {
            for (int index = 0; index < 10; index++)
            {
                Console.Write(index+" ");
            }
            Console.WriteLine("\n"+"========================================");
            int doindex = 0;
            do
            {
                Console.Write(doindex+" ");
                doindex++;
            } while (doindex<10);

            Console.WriteLine("\n"+"========================================");
            int whileindex = 0;
            while (whileindex<10)
            {
                Console.Write(whileindex+" ");
                whileindex++;
            }
            Console.WriteLine("\n" + "====END============");
        }
    }
}
