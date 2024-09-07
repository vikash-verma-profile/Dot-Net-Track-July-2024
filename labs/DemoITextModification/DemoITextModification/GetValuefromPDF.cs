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
            string invoiceNumber = ExtractInvoiceNumber(pdfPath);
            Console.WriteLine(invoiceNumber);

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
    }
}
