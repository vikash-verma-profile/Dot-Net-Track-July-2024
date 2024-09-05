using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWithJquery
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.amazon.com");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Id("twotabsearchtextbox")));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            var script = "if(typeof jQuery == 'undefined'){ " +
                "var script=document.createElement('script');" +
                "script.src='https://code.jquery.com/jquery-3.7.1.min.js';" +
                "document.head.appendChild(script);}";
            js.ExecuteScript(script);
            System.Threading.Thread.Sleep(2000);
            js.ExecuteScript("$('#twotabsearchtextbox').val('laptop');");
            js.ExecuteScript("$(\"input.nav-input[type='submit']\").click();");
            wait.Until(d => d.FindElement(By.CssSelector("span.a-size-medium")));
            js.ExecuteScript(script);
            System.Threading.Thread.Sleep(2000);
            js.ExecuteScript("window.scrollBy(0,500)");
            js.ExecuteScript("$(\"span.a-size-medium.a-color-base.a-text-normal\").first().click()");
            wait.Until(d => d.FindElement(By.Id("productTitle")));
            js.ExecuteScript(script);
            string productTitle = (string)js.ExecuteScript("return $('#productTitle').text().trim();");
            Console.WriteLine(productTitle);

            //get first review
            js.ExecuteScript("document.querySelector('#reviewsMedley').scrollIntoView();");
            string firstReview= (string)js.ExecuteScript("return $('.review-text-content span').first().text().trim();");
            Console.WriteLine(firstReview);
            driver.Quit();
        }
    }
}
