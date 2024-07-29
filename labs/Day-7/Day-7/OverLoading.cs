using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{

    public class OverloadingDemo
    {
        public void Sum()
        {
            Console.WriteLine(1 + 2);
        }

        public void Sum(int a,int b)
        {
            Console.WriteLine(a + b);
        }
        public void Sum(string a, string b)
        {
            Console.WriteLine(a + b);
        }
        public void Sum(int a, int b,int c)
        {
            Console.WriteLine(a + b+c);
        }
    }
    internal class OverLoading
    {
        public static void Main()
        {
            OverloadingDemo overloadingDemo = new OverloadingDemo();
            overloadingDemo.Sum();
            overloadingDemo.Sum(1,2);
            overloadingDemo.Sum(1, 2,3);
            overloadingDemo.Sum("1","2");

        }
    }
}
