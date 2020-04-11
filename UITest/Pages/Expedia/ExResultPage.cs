using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TestProject.UITest.Utilities;

namespace TestProject.UITest.Pages.Expedia
{
    public class ExResultPage:BasePage
    {
        private readonly IWebDriver _driver;

        public ExResultPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private IList<IWebElement> SelectBtnList => _driver.FindElements(By.CssSelector(".btn-secondary.btn-action.t-select-btn"));

        private IWebElement SingleTicketPrice => _driver.FindElement(By.CssSelector("div[data-test-id='select-departure-price']>div>span:last-of-type"));

        private IWebElement ProgressBar => _driver.FindElement(By.CssSelector("#pi-interstitial>div>div"));

        public void ClickSelectBtn()
        {
            ProgressBar.WaitForElementAttribute("100");
            SelectBtnList.WaitForElementsToLoad();
            var selectBtn = UtilMethods.SelectFirstElementFromList(SelectBtnList);
            Wait(1);
            selectBtn.ClickBtn(_driver);
            SingleTicketPrice.WaitForElementLoadTillTextDisplayed();
           // Wait(2);
        }

        public string GetSingleTicketPrice()
        {
            string ticketPrice = "";
            if (SingleTicketPrice.IsElementVisible(Wait(5)))
            {
                Wait(1);
                ticketPrice = SingleTicketPrice.GetText();
                //ScenarioContext.Current.Add("SingleTicketPrice", ticketPrice);
            }
            return ticketPrice;
        }

    }
}
