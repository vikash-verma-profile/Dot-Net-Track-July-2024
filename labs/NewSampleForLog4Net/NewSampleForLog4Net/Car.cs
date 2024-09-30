using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSampleForLog4Net
{
    public class Car
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string Model { get; set; }
        public int YearReleased { get; set; }
        public Person Owner { get; set; }

        public Car(string model,int yearReleased,Person owner)
        {
                Model=model;
            YearReleased=yearReleased;
            Owner=owner;
            logger.Debug($"Created a car {this} at {DateTime.Now}");
            
        }
        public override string ToString()
        {
            return $"[{Model}] ({YearReleased}), owned by {Owner}";
        }
    }
}
