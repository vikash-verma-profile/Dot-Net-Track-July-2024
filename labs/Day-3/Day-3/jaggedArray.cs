using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3
{
    internal class jaggedArray
    {
        static void Main(string[] args)
        {
            int[][] jagged_array = new int[4][];
            jagged_array[0]=new int[] {1,2,3,4};
            jagged_array[1] = new int[] { 11,34,67 };
            jagged_array[2] = new int[] { 0,45 };
            jagged_array[3] = new int[] { 0, 45,87 };

            for (int i = 0; i < jagged_array.Length; i++)
            {
                for (int j = 0; j<jagged_array[i].Length;j++)
                {
                    Console.Write(jagged_array[i][j]+",");
                }
                Console.WriteLine();
            }
        }
    }
}
