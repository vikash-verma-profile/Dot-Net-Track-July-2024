﻿using System;


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
            logger.Debug("some debug log");
            logger.Warn("Warning logs");
            logger.Error("Error logs");
            logger.Fatal("Fatal logs");
            logger.Info("Application has finished");
        }
    }
}
