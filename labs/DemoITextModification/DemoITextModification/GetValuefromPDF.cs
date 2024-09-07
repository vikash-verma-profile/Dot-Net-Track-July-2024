using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Canvas.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoITextModification
{
    internal class GetValuefromPDF
    {
        public static void Main()
        {
            string pdfPath = "invoice.pdf";
            //string invoiceNumber = ExtractInvoiceNumber(pdfPath);
            //Console.WriteLine(invoiceNumber);
            ExtractTableFromPDF(pdfPath);

        }

        public static string ExtractInvoiceNumber(string filename)
        {
            string InvoiceNumner = string.Empty;
            PdfReader pdfReader = new PdfReader(filename);
            PdfDocument pdfDocument = new PdfDocument(pdfReader);
            string InvoiceNumeberPattern = @"Invoice Number:\s*(\S+)";
            for (int i = 1; i <= pdfDocument.GetNumberOfPages(); i++)
            {
                string pageText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(i));
                Match match = Regex.Match(pageText,InvoiceNumeberPattern);
                if (match.Success)
                {
                    InvoiceNumner= match.Groups[1].Value;
                    break;
                }
            }
            pdfDocument.Close();
            return InvoiceNumner;

        }

        public static void ExtractTableFromPDF(string filename)
        {
            PdfReader pdfReader = new PdfReader(filename);
            PdfDocument pdfDocument = new PdfDocument(pdfReader);
            for (int i = 1; i <= pdfDocument.GetNumberOfPages(); i++)
            {
                string pageText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(i));
                ExtractTable(pageText);
            }
            pdfDocument.Close();

        }

        public static void ExtractTable(string pageText)
        {
            string tablePattern = @"Product\s*\d+\s*\d+\s*\$\d+\s*\$\d+";

            MatchCollection matched = Regex.Matches(pageText, tablePattern);
            foreach (Match item in matched)
            {
                string tableRow = item.Groups[0].Value;
                string[] colums = Regex.Split(tableRow.Trim(),@"\s{2,}");
                foreach (var column in colums)
                {
                    Console.Write(column + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
