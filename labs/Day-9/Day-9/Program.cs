namespace Day_9
{
    interface ITest
    {
        void TestMethod();
    }
    class TestClass : ITest
    {
        public void TestMethod() {

            Console.WriteLine("Implicit Interface Implementation");
        }
    }
    class ExplicitTestClass : ITest {

        void ITest.TestMethod()
        {
            Console.WriteLine("Explicit Interface Implementation");
        }
    }
    internal class Program
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
