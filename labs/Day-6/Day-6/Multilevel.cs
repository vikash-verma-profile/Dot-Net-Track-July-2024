using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6
{
    class A
    {
        public A()
        {
            Console.WriteLine("A");
        }
    }
    class B:A
    {
        public B()
        {
            Console.WriteLine("B");
        }
    }
    class C:B
    {
        public C()
        {
            Console.WriteLine("C");
        }

    }
    internal class Multilevel
    {
        public static void Main4()
        {
            C c = new C();
        }
      
    }
}
