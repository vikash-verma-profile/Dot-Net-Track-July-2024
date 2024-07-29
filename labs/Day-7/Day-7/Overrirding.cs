using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
    class baseClass
    {
        public baseClass()
        {
                
        }
        public virtual void show()
        {
            Console.WriteLine("Base class");
        }
    }
    class derivedClass:baseClass
    {
        public derivedClass():base()
        {
                
        }
        public override void show()
        {
            base.show();    
            Console.WriteLine("Derived class");
        }
    }
    internal class Overrirding
    {
        public static void Main()
        {
            baseClass obj=new baseClass();
            obj.show();

            obj=new derivedClass();
            obj.show();
        }
    }
}
