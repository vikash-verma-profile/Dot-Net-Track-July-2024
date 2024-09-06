using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace ITextDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pdfPath = "sampleDemo.pdf";

            using (FileStream fs = new FileStream(pdfPath,FileMode.Create,FileAccess.Write,FileShare.None))
            {
                //initalize a pdfwriter with encription
                WriterProperties writerprops=new WriterProperties().
                    SetStandardEncryption("","",EncryptionConstants.ALLOW_PRINTING,EncryptionConstants.ENCRYPTION_AES_256);

                //Intilize a new pdf document
                PdfWriter writer = new PdfWriter(fs, writerprops);
                PdfDocument pdfDocument = new PdfDocument(writer);

                //Intilize a document for layout
                Document document = new Document(pdfDocument);

                //Add a sample paragraph
                document.Add(new Paragraph("Hello I am a sample text written by vikash"));
                document.Close();
            
            }
            Console.WriteLine("pdf is created !!");
        }
    }
}
