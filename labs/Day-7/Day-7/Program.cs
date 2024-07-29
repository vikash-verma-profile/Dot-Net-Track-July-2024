namespace Day_7
{

    public abstract class Animal
    {
        public abstract string Sound { get; }
    }
    public class Cat : Animal
    {
        public override string Sound => "some sound";

    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
