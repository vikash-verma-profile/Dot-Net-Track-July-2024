using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace Day_13
{
    internal class XSLTDemo
    {
        public static void Main5()
        {
            XslTransform xslt=new XslTransform();
            xslt.Load("C:\\Users\\Level Up Solutions 1\\Desktop\\course-structure\\labs\\Day-13\\Day-13\\XSLT\\Sample.xsl");
            xslt.Transform("C:\\Users\\Level Up Solutions 1\\Desktop\\course-structure\\labs\\Day-13\\Day-13\\xmlfiles\\books.xml", "file.html");
        
        }
    }
}
