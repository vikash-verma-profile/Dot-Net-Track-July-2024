using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
    internal class StreamReadervsStreamWriter
    {
        public static void Main4()
        {
            string FilePath = @"D:\samplefile.txt";
            //StreamWriter streamWriter = new StreamWriter(FilePath,true);
            //Console.WriteLine("Please enter some string to write to file");
            //string inputData = Console.ReadLine();
            //streamWriter.Write(inputData);
            //streamWriter.Flush();
            //streamWriter.Close();

            StreamReader stream = new StreamReader(FilePath);
            Console.WriteLine("Content from the file");
            stream.BaseStream.Seek(0,SeekOrigin.Begin);
            string strData = stream.ReadLine();
            while (strData != null)
            {
                Console.WriteLine(strData);
                strData= stream.ReadLine();
            }
        }
    }
}
