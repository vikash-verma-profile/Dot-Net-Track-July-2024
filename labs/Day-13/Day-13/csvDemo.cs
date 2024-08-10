using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace Day_13
{
    public class CsvParser
    {
        public static List<List<string>> ParseCsv(string filePath)
        {
            var result=new List<List<string>>();
            var lines=File.ReadAllLines(filePath);
            foreach (var item in lines)
            {
                var fields = ParseLine(item);
                result.Add(fields);
            }
            return result;
        }
        private static List<string> ParseLine(string line)
        {
            var fields=new List<string>();
            var sb=new StringBuilder();
            bool inQuotes = false;
            foreach (var item in line)
            {
                if (item == '"')
                {
                    inQuotes = !inQuotes;
                }
                else if(item==',' && !inQuotes)
                {
                    fields.Add(sb.ToString());
                    sb.Clear();
                }
                else
                {
                    sb.Append(item);
                }
            }
            fields.Add(sb.ToString());
            return fields;
        }
    }
    internal class csvDemo
    {
        public static void Main()
        {

            var directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent;
            var filePath = directory + "\\csvfiles\\books.csv";

            //var csvData = CsvParser.ParseCsv(filePath);
            //foreach (var row in csvData)
            //{
            //    foreach (var field in row)
            //    {
            //        Console.Write(field+" | ");
            //    }
            //    Console.WriteLine();
            //}

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader,new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture));

            var records = csv.GetRecords<dynamic>().ToList();
            foreach (var item in records)
            {
                Console.WriteLine(item.ISBN+ " | "+item.BookName+" | "+item.Author);
            }
        }
    }
}
