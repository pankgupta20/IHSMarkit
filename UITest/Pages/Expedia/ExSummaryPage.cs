using OpenQA.Selenium;
using System.Collections.Generic;
using TestProject.UITest.Utilities;

namespace TestProject.UITest.Pages.Expedia
{
    public class ExSummaryPage:BasePage
    {
        private readonly IWebDriver _driver;

        public ExSummaryPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IList<IWebElement> TotalPrice => _driver.FindElements(By.CssSelector(".packagePriceTotal"));


        public string GetTotalPrice()
        {
            _driver.SwitchToLastWindow();
            return TotalPrice.SelectVisibleElementFromList().GetText();
        }

    }
}
