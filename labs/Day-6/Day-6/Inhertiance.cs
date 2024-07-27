using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6
{
    class VehicleDemo
    {
        protected string name;
        public VehicleDemo()
        {
            name = "Honda";
        }
    }
    class Bike : VehicleDemo
    {
        public void Print()
        {
            Console.WriteLine(name);
        }
    }
    class Scotter : VehicleDemo
    {
        public void Print()
        {
            Console.WriteLine(name);
        }
    }
    internal class Inhertiance
    {
        public static void Main3()
        {
            Bike b = new Bike();
            b.Print();

            Scotter scotter = new Scotter();
            scotter.Print();
        }
    }
}
