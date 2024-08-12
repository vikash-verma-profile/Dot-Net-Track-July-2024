using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace Day_14
{
    internal class ExcelDemowithc_
    {
        public static void Main2()
        {
            var directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent;
            var filePath = directory + "\\excelfiles\\Book1.xlsx";
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var excelPackageObject=new ExcelPackage(filePath))
            {
                var workSheet = excelPackageObject.Workbook.Worksheets[0];
                var rowCount = workSheet.Dimension.Rows;
                var colCount = workSheet.Dimension.Columns;
                for (int row = 1; row <= rowCount; row++)
                {
                    for (int col = 1; col <= colCount; col++)
                    {
                        var cellValue = workSheet.Cells[row, col].Text;
                        Console.WriteLine($"{cellValue}");
                    }
                    Console.WriteLine();
                }
            }

        }
    }
}
