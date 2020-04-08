using OpenQA.Selenium;

namespace TestProject.UITest.Pages
{
   public class HomePage:BasePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IWebElement Signin => _driver.FindElement(By.CssSelector(".login"));

        public void ClickSignin()
        {
            Signin.Click();
        }
    }
}
