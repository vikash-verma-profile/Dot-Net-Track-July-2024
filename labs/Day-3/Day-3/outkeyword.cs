using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3
{
    internal class outkeyword
    {
        //out
        public static void sumOut(int a,int b,out int result)
        {
            result = a + b;
        }
        //ref
        public static void sumRef(ref int a, ref int b)
        {
             Console.WriteLine(a + b);
        }
        static void Main3(string[] args)
        {
            int output=0, a=1, b=3;
            sumOut(a,b, out output);
            sumRef(ref a, ref b);
            Console.WriteLine(output);
        }
    }
}
