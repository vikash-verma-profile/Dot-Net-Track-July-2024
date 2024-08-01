namespace Day_8
{
    public abstract class Animal
    {
        public abstract string Sound { get; }

        public virtual void Move()
        {
            Console.WriteLine("Animal is moving in base class");
        }
        public abstract void Print();
    }

    public class Cat : Animal
    {
        public override string Sound => "Meow";
        public override void Move()
        {
            Console.WriteLine("Cat is moving in derived class");

        }
        public override void Print()
        {
            Console.WriteLine("Hello I am abstract method in Cat");
        }
    }
    public class Dog : Animal
    {
        public override string Sound => "Bark";
        public override void Move()
        {
            Console.WriteLine("Dog is moving in derived class");

        }
        public override void Print()
        {
            Console.WriteLine("Hello I am abstract method in Dog");
        }
    }
    internal class Program
    {
        static void Main1(string[] args)
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
