namespace Day_2
{
    internal class Program
    {
        // Implicit vs explicit

        /*
         * 
         */
        static void Main1(string[] args)
        {
            int Number = 15;
            //get type
            Type typeOfVariable=Number.GetType();

            //Implicit
            double numDouble = Number;
            Console.WriteLine(numDouble);// increment

            int NumerInt = (int)numDouble;//decrement

            int NumerLong = Convert.ToInt32(numDouble);
        }
    }
}
