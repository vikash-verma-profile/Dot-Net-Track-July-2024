using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
    internal class FileClasDemo
    {
        public static void Main4()
        {
            string SourceFilePath = @"D:\samplefile.txt";
            string DestintionFilePath = @"D:\FileDemo\samplefile.txt";
            string NewFilePath = @"D:\FileDemo\samplefileNew.txt";
            if (File.Exists(SourceFilePath))
            {
                File.Copy(SourceFilePath, DestintionFilePath,true);
                File.Delete(DestintionFilePath);
                File.Create(NewFilePath);
            }
            else
            {
                Console.WriteLine("File does not exists");
            }
        }
    }
}
