using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_9
{

    interface IWholeSeller
    {
        void Discount();
    }
    interface IRetailer
    {
         void Discount();
    }
    class Buyer : IWholeSeller, IRetailer
    {
         void IWholeSeller.Discount() {
            Console.WriteLine("Hi i am called from DEMO IWholeSeller");
        }
         void IRetailer.Discount()
        {
            Console.WriteLine("Hi i am called from DEMO IRetailer");
        }
        public void Print()
        {
            
        }
    }
    internal class MultipleInterfaceIssue
    {
        public static void Main()
        {
            IWholeSeller d1 = new Buyer();
            d1.Discount();

            IRetailer d2 = new Buyer();
            d2.Discount();

        }
    }
}
