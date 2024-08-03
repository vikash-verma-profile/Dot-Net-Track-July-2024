using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
    internal class DirectoryInfoClasDemo
    {
        public static void Main()
        {
            string NewFilePath = @"D:\FileDemo\Sample";
            string NewFilePath1 = @"D:\FileDemo1\Sample1";
            string NewFilePath2 = @"D:\FileDemo2";
            DirectoryInfo f1=new DirectoryInfo(NewFilePath);
            //f1.Create();
            //f1.CreateSubdirectory("TestSample");
            DirectoryInfo d1 = new DirectoryInfo(NewFilePath);
            DirectoryInfo d2 = new DirectoryInfo(NewFilePath1);
            //d1.MoveTo(NewFilePath2);
            DirectoryInfo d3 = new DirectoryInfo(NewFilePath2);
            d3.Delete();

        }
    }
}
