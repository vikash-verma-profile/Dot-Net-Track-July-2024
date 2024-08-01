namespace Day_8
{
    public abstract class Animal
    {
        public abstract string Sound { get; }

        public virtual void Move()
        {
            Console.WriteLine("Animal is moving in base class");
        }
    }

    public class Cat : Animal
    {
        public override string Sound => "Meow";
        public override void Move()
        {
            Console.WriteLine("Cat is moving in derived class");

        }
    }
    public class Dog : Animal
    {
        public override string Sound => "Bark";
        public override void Move()
        {
            Console.WriteLine("Dog is moving in derived class");

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals = new Animal[] { new Cat(), new Dog() };

            foreach (var anim in animals)
            {
                Console.WriteLine($"The {anim.GetType().Name} goes {anim.Sound}");
                anim.Move();
            }
        }
    }
}
