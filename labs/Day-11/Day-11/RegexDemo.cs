using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_11
{
    internal class RegexDemo
    {
        static void Main2(string[] args)
        {
            //b,ab,aab,
            string pattern1 = "a*b";//preceding charcter zero or more
            string pattern2 = "a+b";//preceding charcter  one or more
            string pattern3 = "a?b";//preceding charcter  zero or one
            Regex rex = new Regex(pattern3);
            string x = "1234";
            Match match=rex.Match("aaaasdasdbcd");
            if (match.Success)
            {
                Console.WriteLine("success");
            }
            else
            {
                Console.WriteLine("fail");

            }

        }
    }
}
