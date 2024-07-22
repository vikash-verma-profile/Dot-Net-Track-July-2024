using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3
{
    internal class arrays
    {
        static void Main4(string[] args)
        {
            int[] sample = new int[4];
            int[,] sample2D = new int[4,4];
            for (int i = 0; i < sample.Length; i++)
            {
                sample[i] = Convert.ToInt16(Console.ReadLine());
            }

            Console.WriteLine("===============================");
            for (int i = 0; i < sample.Length; i++)
            {
                Console.WriteLine(sample[i]);
            }
        }
    }
}
