using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
    internal class Filehandling
    {
        public static void Main3()
        {
            string FilePath = @"D:\samplefile.txt";

            //FileStream fileStream = new FileStream(FilePath,FileMode.Append);
            //byte[] byteData = Encoding.Default.GetBytes("Hello I am vikash Verma");
            //fileStream.Write(byteData,0,byteData.Length);
            FileStream fileStream = new FileStream(FilePath, FileMode.Open,FileAccess.Read);
            string Data;
            using (StreamReader streamReader=new StreamReader(fileStream))
            {
                Data=streamReader.ReadToEnd();
            }
            Console.WriteLine(Data);    
            fileStream.Close();

        }
    }
}
