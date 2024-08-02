using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_9
{
    internal class DictionaryDemo
    {
        public static void Main()
        {
            Dictionary<int,string> myDictionay = new Dictionary<int,string>();
            myDictionay.Add(1,"Vikash");
            myDictionay.Add(2, "Rakesh");
            myDictionay.Add(3, "Suresh");

            foreach (KeyValuePair<int,string> item in myDictionay)
            {
                Console.WriteLine("Key :{0},Value:{1}",item.Key,item.Value);
            }
            Console.WriteLine("====================================");
            HashSet<int> myset=new HashSet<int>();
            myset.Add(1);
            myset.Add(2);
            myset.Add(3);
            myset.Add(2);
            foreach (var item in myset)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("====================================");
            Queue<int> myQueue = new Queue<int>();
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            while(myQueue.Count>0)
            {
                Console.WriteLine(myQueue.Dequeue());
            }

            Console.WriteLine("====================================");
            Stack<int> myStack = new Stack<int>();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            while (myStack.Count > 0)
            {
                Console.WriteLine(myStack.Pop());
            }


        }
    }
}
