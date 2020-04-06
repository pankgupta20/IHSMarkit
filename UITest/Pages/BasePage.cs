using OpenQA.Selenium;

namespace TestProject.UITest.Pages
{
    public class BasePage
    {
        private readonly IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void OpenUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
    }
}
