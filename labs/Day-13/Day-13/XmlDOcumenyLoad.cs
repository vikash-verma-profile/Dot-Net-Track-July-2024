using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Day_13
{
    internal class XmlDOcumenyLoad
    {
        public static void Main()
        {
            XmlDocument xmlDoc=new XmlDocument();
            string filename = "C:\\Users\\Level Up Solutions 1\\Desktop\\course-structure\\labs\\Day-13\\Day-13\\xmlfiles\\books.xml";
            xmlDoc.Load(filename);
            xmlDoc.Save(Console.Out);

            Console.WriteLine("\n =============================");

            XmlDocument xmlDoc1 = new XmlDocument();
            XmlTextReader reader = new XmlTextReader("C:\\Users\\Level Up Solutions 1\\Desktop\\course-structure\\labs\\Day-13\\Day-13\\xmlfiles\\books.xml");
            xmlDoc1.Load(reader);
            xmlDoc1.Save(Console.Out);

            XmlTextWriter writer =new XmlTextWriter("C:\\Users\\Level Up Solutions 1\\Desktop\\course-structure\\labs\\Day-13\\Day-13\\xmlfiles\\domTest.xml",null);
            writer.Formatting=Formatting.Indented; ;
            //xmlDoc.Save(writer);

            XmlDocumentFragment xoc = xmlDoc.CreateDocumentFragment();
            xoc.InnerXml = "<Record>write some demo sample text</Record>";
            Console.WriteLine(xoc.InnerXml);

            XmlNode root = xmlDoc.DocumentElement;
            root.AppendChild(xoc);
            xmlDoc.Save(writer);
        }
    }
}
