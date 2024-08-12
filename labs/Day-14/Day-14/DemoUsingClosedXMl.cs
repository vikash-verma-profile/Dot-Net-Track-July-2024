using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_14
{
    internal class DemoUsingClosedXMl
    {
        public static void Main()
        {
            var directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent;
            var filePath = directory + "\\excelfiles\\BookRecords.xlsx";

            var bookData = new[,]
          {
              {"BookName","ISBN","Author"},
              {"Lets learn C#","78576567","Vikash Verma"},
               {"Clean code with C#","87657856","Sashi Kumar"},
                {"Refectoring with C#","87687","Priya sharma"},
            };
            using (var workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add("booksheet");
              
                for (int row = 0; row < bookData.GetLength(0); row++)
                {
                    for (int col = 0; col < bookData.GetLength(1); col++)
                    {
                        workSheet.Cell(row+1, col+1).Value= bookData[row,col];
                    }   
                }
                workbook.SaveAs(filePath);
            }
            Console.WriteLine("Written in file successfull");
        }
    }
}
