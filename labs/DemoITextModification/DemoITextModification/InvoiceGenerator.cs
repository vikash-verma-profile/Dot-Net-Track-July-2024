using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Geom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Colors;

namespace DemoITextModification
{
    internal class InvoiceGenerator
    {
        static void Main2(string[] args)
        {
            string outputPath = "invoice.pdf";

            PdfWriter pdfWriter = new PdfWriter(outputPath);
            PdfDocument pdfDocument = new PdfDocument(pdfWriter);
            Document document=new Document(pdfDocument);
            string watermarkText = "PAID";
            document.Add(new Paragraph("INVOICE").
                SetTextAlignment(TextAlignment.CENTER).SetFontSize(24).SetBold());
            //Add company and customer details

            document.Add(new Paragraph("Company Name: ABC E-COMMERCE LTd.\n Address : Mumbai 122001").SetFontSize(12).SetMarginBottom(10));
            document.Add(new Paragraph("Customer Name: Vikash Verma\n Address : Gurgaon 122001").SetFontSize(12).SetMarginBottom(20));

            document.Add(new Paragraph("Invoice Number: INV-001\n Invoice Date: "+System.DateTime.Now.ToString("MM/dd/yyyy")).SetFontSize(12).SetMarginBottom(20));


            Table table = new Table(new float[] { 4,1,2,2}); //set column widths
            table.SetWidth(UnitValue.CreatePercentValue(100));

            table.AddHeaderCell(new Cell().Add(new Paragraph("Item Description").SetBold()));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Quantity").SetBold()));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Price Per Item").SetBold()));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Total").SetBold()));

            //add product rows
            table.AddCell(new Cell().Add(new Paragraph("Product 1")));
            table.AddCell(new Cell().Add(new Paragraph("2")));
            table.AddCell(new Cell().Add(new Paragraph("$20")));
            table.AddCell(new Cell().Add(new Paragraph("$40")));

            table.AddCell(new Cell().Add(new Paragraph("Product 2")));
            table.AddCell(new Cell().Add(new Paragraph("2")));
            table.AddCell(new Cell().Add(new Paragraph("$20")));
            table.AddCell(new Cell().Add(new Paragraph("$40")));

            table.AddCell(new Cell().Add(new Paragraph("Product 3")));
            table.AddCell(new Cell().Add(new Paragraph("2")));
            table.AddCell(new Cell().Add(new Paragraph("$20")));
            table.AddCell(new Cell().Add(new Paragraph("$40")));
            document.Add(table);

            document.Add(new Paragraph("\n Total Amount Due : $40").SetFontSize(14).SetBold().
                
                SetTextAlignment(TextAlignment.RIGHT).SetMarginTop(20));

            document.Close();

            AddPaidWaterMark();
        }

        public static void AddPaidWaterMark()
        {
            string inputpdfPath = "invoice.pdf";
            string outputpdfPath = "invoice_watermark.pdf";

            PdfReader pdfReader = new PdfReader(inputpdfPath, new ReaderProperties().SetPassword(Encoding.UTF8.GetBytes("owner123")));
            PdfWriter pdfWriter = new PdfWriter(outputpdfPath);
            PdfDocument pdfDocument = new PdfDocument(pdfReader, pdfWriter);

            int numberOfPages = pdfDocument.GetNumberOfPages();

            for (int i = 1; i <= numberOfPages; i++)
            {
                PdfPage page = pdfDocument.GetPage(i);
                Rectangle pageSize = page.GetPageSize();

                PdfCanvas canvas = new PdfCanvas(page);
                canvas.SaveState();
                canvas.SetFillColor(ColorConstants.LIGHT_GRAY);

                canvas.BeginText().SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.HELVETICA), 60).
                    SetTextMatrix(30, 30).MoveText(page.GetPageSize().GetWidth()/4,page.GetPageSize().GetHeight()/2).ShowText("PAID").EndText();
                canvas.RestoreState();
            }
            pdfDocument.Close();
        }
    }
}
