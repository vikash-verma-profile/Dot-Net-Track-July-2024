using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Day_13
{
    internal class newReadxml
    {
        public static void Main()
        {
            XmlTextWriter writer = new XmlTextWriter("C:\\Users\\Level Up Solutions 1\\Desktop\\course-structure\\labs\\Day-13\\Day-13\\xmlfiles\\XmlTextWriterTEST.xml", null);
            XmlTextReader reader = new XmlTextReader("C:\\Users\\Level Up Solutions 1\\Desktop\\course-structure\\labs\\Day-13\\Day-13\\xmlfiles\\books.xml");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    writer.WriteNode(reader, true);
                }
            }
            writer.Close();
        }
    }
}
