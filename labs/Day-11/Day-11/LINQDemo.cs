using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11
{
    internal class LINQDemo
    {
        public static void Main4()
        {
            string[] languages = { "c#", "java", "C++", "Ruby", "C", "perl" };
            var result = from lang in languages where lang.Contains('C') select lang ;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
