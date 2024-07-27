using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6
{
    class Vehicle
    {
        private string name;
        private string color;
        //copy constructor
        public Vehicle(Vehicle vehicle)
        {
            name = vehicle.name;
            color = vehicle.color;
        }
        public Vehicle(string name,string color)
        {
            this.name = name;
            this.color = color;
        }
        public void PrintData()
        {
            Console.WriteLine("Model Name:" + name+"\n color: "+color);
        }

        public override string ToString()
        {
            return "Hello";
        }

        //Destructor
        ~ Vehicle()
        {
                
        }
    }
    internal class CopyCOnstructor
    {
        public static void Main2()
        {
            Vehicle v1 = new Vehicle("Bike","Black");
            Vehicle v2 = new Vehicle(v1);
            v2.PrintData();
            Console.WriteLine(v2);


        }
    }
}
