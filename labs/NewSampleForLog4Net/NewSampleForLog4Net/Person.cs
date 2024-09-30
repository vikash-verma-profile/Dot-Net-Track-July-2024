using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSampleForLog4Net
{
    public class Person
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public string Name { get; set; }
        public string lastName { get; set; }
        public Person(string name,string lastName)
        {
            Name = name;
            lastName = lastName;
            logger.Info($"Create a person {this} at { DateTime.Now}");
        }
        public override string ToString()
        {
            return $"[{Name} {lastName}]"; 
        }
    }
}
