using OpenQA.Selenium;
using System;

namespace TestProject.UITest.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement Email => _driver.FindElement(By.CssSelector("#email"));

        private IWebElement Password => _driver.FindElement(By.CssSelector("#passwd"));

        private IWebElement Signin => _driver.FindElement(By.CssSelector("#SubmitLogin"));

        private IWebElement ErrorMessage => _driver.FindElement(By.CssSelector("div.alert.alert-danger>ol>li"));

        public void Login(string uname, string password)
        {
            Email.SendKeys(uname);
            Password.SendKeys(password);
        }

        public void Submit()
        {
            Signin.Click();
        }

        public string GetErrorMessage()
        {
            if (!(ErrorMessage.Text == ""))
            {
                return ErrorMessage.Text;
            }
            return string.Empty;
        }
    }
}
