using System.Collections;

namespace Day_10
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            ArrayList al = new ArrayList();
            string str = "Vikash Verma";
            int x = 7;
            DateTime d =DateTime.Parse("03-08-2024");

            al.Add(str);
            al.Add(x);
            al.Add(d);

            foreach (var item in al)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("===============================");
            Hashtable ht=new Hashtable();
            ht.Add("ora", "Oracle");
            ht.Add("vb", "vb.net");
            ht.Add("cs", "cs.net");
            ht.Add("asp", "asp.net");

            foreach (DictionaryEntry item in ht)
            {
                Console.WriteLine(item.Key+" "+item.Value);
            }
            Console.WriteLine("===============================");

            SortedList sl = new SortedList();
            sl.Add("ora", "Oracle");
            sl.Add("vb", "vb.net");
            sl.Add("cs", "cs.net");
            sl.Add("asp", "asp.net");

            foreach (DictionaryEntry item in sl)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            Console.WriteLine("===============================");
            Stack stk = new Stack();
            stk.Push("Oracle");
            stk.Push("vb.net");
            stk.Push("cs.net");
            stk.Push("asp.net");

            foreach (var item in stk)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("===============================");
            Queue q = new Queue();
            q.Enqueue("Oracle");
            q.Enqueue("vb.net");
            q.Enqueue("cs.net");
            q.Enqueue("asp.net");

            foreach (var item in q)
            {
                Console.WriteLine(item);
            }
        }
    }
}
