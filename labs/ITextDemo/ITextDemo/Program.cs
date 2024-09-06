using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.IO;
using System.Text;

namespace ITextDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pdfPath = "sampleDemo.pdf";

            using (FileStream fs = new FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                // Initialize PdfWriter with encryption
                WriterProperties writerProps = new WriterProperties()
                    .SetStandardEncryption(
                        Encoding.UTF8.GetBytes("user123"),
                        Encoding.UTF8.GetBytes("owner123"),
                        EncryptionConstants.ALLOW_PRINTING,
                        EncryptionConstants.ENCRYPTION_AES_256
                    );

                // Initialize a new PdfDocument
                PdfWriter writer = new PdfWriter(fs, writerProps);
                PdfDocument pdfDocument = new PdfDocument(writer);

                // Initialize a Document for layout
                Document document = new Document(pdfDocument);

                // Add a sample paragraph
                document.Add(new Paragraph("Hello I am a sample text written by Vikash"));
                document.Close();
            }

            Console.WriteLine("PDF is created!!");
        }
    }
}
