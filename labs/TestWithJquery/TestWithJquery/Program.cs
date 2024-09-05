using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestWithJquery
{
    internal class Program
    {
        static void Main1(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            //wait.Until(d => d.FindElement(By.Name("q")));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            //js.ExecuteScript("$(\"input[name='q']\").val('jQuery');");
            //js.ExecuteScript("$(\"input[name='q']\").submit()");

            js.ExecuteScript("$('#firstName').val('jQuery');");
            //js.ExecuteScript("$(\"input[name='q']\").submit()");
            //driver.Quit();
        }
    }
}
