using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5
{
    public class TestDemo
    {
        public int aVariable;
        public TestDemo(int sample)
        {
            aVariable = sample;
        }

        public void PrintData()
        {
            Console.WriteLine(aVariable);
        }
    }
    internal class VariblesDemo
    {
        public static void Main3()
        {
            TestDemo t1 = new TestDemo(1);
            TestDemo t2 = new TestDemo(2);
            Console.WriteLine(t1.aVariable);
            Console.WriteLine(t2.aVariable);

        }
    }
}
