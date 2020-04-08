using OpenQA.Selenium;
using System;
using TestProject.UITest.Utilities;

namespace TestProject.UITest.Pages
{
    public class BasePage
    {
        private readonly IWebDriver _driver;
        public readonly string AutomationPracticeUrl = "http://automationpractice.com/index.php";
        public readonly string ExpediaUrl = "https://www.expedia.com/";

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void OpenUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
             UtilMethods.WaitForPageLoaded(_driver,30);
        }

        public TimeSpan Wait(int waitTime)
        {
            return TimeSpan.FromSeconds(waitTime);
        }
    }
}
