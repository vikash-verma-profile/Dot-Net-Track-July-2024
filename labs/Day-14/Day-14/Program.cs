using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;

namespace Day_14
{

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent;
            var filePath = directory + "\\csvfiles\\books.csv";

            List<Person> peopleList = new List<Person>
            {
                new Person{FirstName="Vikash",LastName="Verma",Age=40},
                new Person{FirstName="Satish",LastName="Sharma",Age=70}
            };

            using var writer = new StreamWriter(filePath);
            using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));
            {
                csv.WriteRecords(peopleList);
            }

        }
    }
}
