﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Day_13
{
    internal class xmldemos
    {
        public static void Main()
        {

            XmlTextReader reader = new XmlTextReader("C:\\Users\\Level Up Solutions 1\\Desktop\\course-structure\\labs\\Day-13\\Day-13\\xmlfiles\\books.xml");
            Console.WriteLine(reader.Name);
            Console.WriteLine(reader.BaseURI);
            Console.WriteLine(reader.LocalName);
            while (reader.Read())
            {
                if (reader.HasValue)
                {
                    //Console.WriteLine("Name: "+reader.Value);
                    //Console.WriteLine("Node Depth: " + reader.Depth.ToString());
                    Console.WriteLine("Value: " + reader.Value);

                }
            }

        }
    }
}
