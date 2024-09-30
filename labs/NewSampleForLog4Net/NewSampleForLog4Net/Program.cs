using System;


[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

namespace NewSampleForLog4Net
{
    internal class Program
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            logger.Info("Application is starting");
            var person1 = new Person("Vikash","Verma");
            var person2 = new Person("Suresh", "Kumar");

            var car1 = new Car("Tesla Model S", 2020, person1);
            var car2 = new Car("Tesla Model X", 2020, person2);

            logger.Debug("some debug log");
            logger.Warn("Warning logs");
            logger.Info($"person 1: {person1}"); 
            logger.Info($"car 2: {car2}");
            logger.Error("Error logs");
            logger.Fatal("Fatal logs");
            logger.Error($"Error Ocurred at {DateTime.Now}");
            logger.Info("Application has finished");
        }
    }
}
