using System.Collections;

namespace Day_10
{
    internal class Program
    {
        static void Main(string[] args)
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

        }
    }
}
