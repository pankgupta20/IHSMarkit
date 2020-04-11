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

        private IList<IWebElement> CityList => _driver.FindElements(By.CssSelector(".dateAndOD.cf>div.odPair>div"));

        private IList<IWebElement> DepartureDates => _driver.FindElements(By.CssSelector(".dateAndOD.cf>div.departureDate.type-500"));

        private IList<IWebElement> SinglePriceList => _driver.FindElements(By.CssSelector("[id ^= 'totalPriceForPassenger'][id$= '-desktopView']"));

        private IList<IWebElement> TripDetails => _driver.FindElements(By.CssSelector("[class^='uitk-grid all-x-gutter-12']>div>div>div>h3"));

        private readonly string _prefixDeparture = "//div[starts-with(@class,'uitk-grid all-x-gutter-12 flex-listing flightSummary desktop')]/div/div/div/h3[contains(text(),'Departure')]/";
        private readonly string _dateSuffix = "following-sibling::div/div[starts-with(@class,'departureDate')]";
        private readonly string _citySuffix = "following-sibling::div/div[2]/div";
        private readonly string _prefixReturn = "//div[starts-with(@class,'uitk-grid all-x-gutter-12 flex-listing flightSummary desktop')]/div/div/div/h3[contains(text(),'Return')]/";

        public string GetTotalPrice()
        {
            _driver.SwitchToLastWindow();
            return TotalPrice.SelectVisibleElementFromList().GetText();
        }

        public string GetDepartDate()
        {
            By by = By.XPath(_prefixDeparture + _dateSuffix);
            IWebElement element= _driver.GetElementFromActivePage(by);
            return element.GetText();
        }

        public IList<IWebElement> GetDepartCityList()
        {
            By by = By.XPath(_prefixDeparture + _citySuffix);
            _driver.SwitchToLastWindow();
            Wait(1);
            IList<IWebElement> elementList = _driver.GetElementListFromActivePage(by);
            return elementList;
        }

        public string GetReturnDate()
        {
            By by = By.XPath(_prefixReturn + _dateSuffix);
            IWebElement element = _driver.GetElementFromActivePage(by);
            return element.GetText();
        }

        public IList<IWebElement> GetReturnCityList()
        {
            By by = By.XPath(_prefixReturn + _citySuffix);
            IList<IWebElement> elementList = _driver.GetElementListFromActivePage(by);
            return elementList;
        }

        public string GetCityCode(IList<IWebElement> elementList, int index)
        {
            return _driver.GetElementTextAtGivenIndex(elementList, index);
        }

        public string GetSingleTicketPrice()
        {
            return UtilMethods.SelectFirstElementFromList(SinglePriceList).GetText().Substring(1).Trim();
        }
    }
}
