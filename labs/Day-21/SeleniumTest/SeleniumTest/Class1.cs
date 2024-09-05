﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest
{
    internal class Class1
    {
        public static void Main2()
        {
            IWebDriver driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("https://www.whatismyip.com/");
            //IWebElement ipElement = driver.FindElement(By.XPath("//div/a[@id='ipv4']"));
            //string ipAddress = ipElement.Text;
            //Console.WriteLine(ipAddress);

            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            IWebElement ipElement = driver.FindElement(By.XPath("//body/center/font"));
            string ipAddress = ipElement.Text;
            Console.WriteLine(ipAddress);
        }
    }
}