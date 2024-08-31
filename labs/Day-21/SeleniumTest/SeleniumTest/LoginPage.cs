using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver,TimeSpan.FromSeconds(10));
        }
        public IWebElement UsernameField=> _driver.FindElement(By.Id("user-name"));
        public IWebElement PasswordField => _driver.FindElement(By.Id("password"));
        public IWebElement LoginButton=> _driver.FindElement(By.Id("login-button"));

        public void EnterUserName(string userName)
        {
            UsernameField.SendKeys(userName);
        }
        public void EnterPassword(string password)
        {
            PasswordField.SendKeys(password);
        }
        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public void Login(string username,string password)
        {
            EnterUserName(username);
            EnterPassword(password);
            ClickLoginButton();
        }
    }
}
