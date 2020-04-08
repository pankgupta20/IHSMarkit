using OpenQA.Selenium;
using System;
using TestProject.UITest.Utilities;

namespace TestProject.UITest.Pages
{
    public class LoginPage:BasePage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver):base(driver)
        {
            _driver = driver;
        }

        private IWebElement Email => _driver.FindElement(By.CssSelector("#email"));

        private IWebElement Password => _driver.FindElement(By.CssSelector("#passwd"));

        private IWebElement Signin => _driver.FindElement(By.CssSelector("#SubmitLogin"));

        private IWebElement ErrorMessage => _driver.FindElement(By.CssSelector("div.alert.alert-danger>ol>li"));

        public void Login(string uname, string password)
        {
            Email.SendInput(uname,TimeSpan.FromSeconds(1));
            Password.SendInput(password, TimeSpan.FromSeconds(1));
        }

        public void Submit()
        {
            Signin.Click();
        }

        public string GetErrorMessage()
        {
            return ErrorMessage.GetText();
        }
    }
}
