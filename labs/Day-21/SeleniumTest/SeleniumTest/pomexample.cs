using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest
{
    internal class pomexample
    {
         
        public static void Main()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            LoginPage _loginPage = new LoginPage(driver);
            _loginPage.Login("standard_user", "secret_sauce");

        }
    }
}
