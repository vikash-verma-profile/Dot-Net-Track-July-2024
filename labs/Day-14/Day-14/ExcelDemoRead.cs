using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_14
{
    internal class ExcelDemoRead
    {
        public static void Main3()
        {
            var directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent;
            var filePath = directory + "\\excelfiles\\Book1.xlsx";

            using (var workbook=new XLWorkbook(filePath))
            {
                var workSheet = workbook.Worksheet(1);
                var rowCount = workSheet.RowsUsed().Count();
                var colCount = workSheet.ColumnsUsed().Count();
                for (int row = 1; row <= rowCount; row++)
                {
                    for (int col = 1; col <= colCount; col++)
                    {
                        var cellValue = workSheet.Cell(row, col).GetValue<string>();
                        Console.WriteLine($"{cellValue}");
                    }
                    Console.WriteLine();
                }

            }
        }
    }
}
