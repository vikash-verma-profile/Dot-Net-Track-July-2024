using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5
{
    internal class StaticDemo
    {

        class SampleStaticClass
        {
            static SampleStaticClass()
            {
                Console.WriteLine("Hello i am from static class");
            }
            public static int a;

            public static void printData()
            {
                Console.WriteLine(a);
            }
        }
        public static void Main()
        {
            //SampleStaticClass s = new SampleStaticClass();
            SampleStaticClass.a = 1;
            //SampleStaticClass.printData();
        }
    }
}
