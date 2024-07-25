using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4
{
    internal class StringvsStringBuilder
    {
        static void Main2(string[] args)
        {
            string s = string.Empty;
            s = "Vikash";
            s.ToUpper();
            StringBuilder sb=new StringBuilder();
            sb.Append(s);
            sb=new StringBuilder();
            sb.Clear();
            Console.WriteLine(sb.ToString());

            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(s[i]);
            }
        }
    }
}
