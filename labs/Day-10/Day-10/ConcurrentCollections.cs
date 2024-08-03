using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
    internal class ConcurrentCollections
    {
        public static void Main2()
        {
            BlockingCollection<int> blockingCollection=new BlockingCollection<int>();
            blockingCollection.Add(10);
            blockingCollection.Add(20);
            if(blockingCollection.TryAdd(30,TimeSpan.FromSeconds(1)))
            {
                Console.WriteLine("item added");
            }
            else
            {
                Console.WriteLine("item is not added ");
            }

            ConcurrentStack<int> stackCollection = new ConcurrentStack<int>();
            stackCollection.Push(10);
            stackCollection.Push(20);

            foreach (var item in stackCollection)
            {
                Console.WriteLine(item);
            }
           
        }
    }
}
