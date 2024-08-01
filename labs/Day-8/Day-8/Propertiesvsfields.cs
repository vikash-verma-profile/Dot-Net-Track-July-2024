using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8
{
    //properties vs fields

    public class Sample
    {
        public int _demo; //field
        public int Demo { get; set; } //property
        
       
        //field
        private string _defaultDiscount;

        public Sample()
        {
            _defaultDiscount = "10%";
        }

        public string Myfield { get { return _defaultDiscount; } set { _defaultDiscount = value; } }

        //Autoproperty
        public int MyProperty { get; set; }

    }
    internal class Propertiesvsfields
    {
        public static void Main2()
        {
            Sample s = new Sample();
            Console.Write(s.Myfield);
        }
    }
}
