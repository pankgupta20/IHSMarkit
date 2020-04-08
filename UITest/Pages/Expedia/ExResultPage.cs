using OpenQA.Selenium;
using System.Collections.Generic;
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

        public void ClickSelectBtn()
        {
            SelectBtnList.WaitForElementsToLoad();
            var selectBtn = UtilMethods.SelectFirstElementFromList(SelectBtnList);
            Wait(1);
            selectBtn.ClickBtn(_driver);
        }

        public string GetSingleTicketPrice()
        {
            string ticketPrice = "";
            if (SingleTicketPrice.IsElementVisible(Wait(5)))
            {
                ticketPrice = SingleTicketPrice.GetText();
            }
            return ticketPrice;
        }

    }
}
