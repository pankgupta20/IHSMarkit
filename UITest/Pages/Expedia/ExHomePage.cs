using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TestProject.UITest.Utilities;

namespace TestProject.UITest.Pages.Expedia
{
   public class ExHomePage : BasePage
    {
        private readonly IWebDriver _driver;

        public ExHomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        #region Locators
        private IWebElement FlightsTab => _driver.FindElement(By.CssSelector("#tab-flight-tab-hp"));

        private IWebElement MultiCityTab => _driver.FindElement(By.CssSelector("#flight-type-multi-dest-label-hp-flight"));

        private IWebElement FlyFrom1 => _driver.FindElement(By.CssSelector("#flight-origin-hp-flight"));

        private IWebElement GoingTo1 => _driver.FindElement(By.CssSelector("#flight-destination-hp-flight"));

        private IWebElement FlyFrom2 => _driver.FindElement(By.CssSelector("#flight-2-origin-hp-flight"));

        private IWebElement GoingTo2 => _driver.FindElement(By.CssSelector("#flight-2-destination-hp-flight"));

        private IWebElement DepartingDate1 => _driver.FindElement(By.CssSelector("#flight-departing-single-hp-flight"));

        private IWebElement DepartingDate2 => _driver.FindElement(By.CssSelector("#flight-2-departing-hp-flight"));

        private IWebElement CloseCalendar => _driver.FindElement(By.CssSelector(".datepicker-close-btn.close.btn-text"));

        private IWebElement Travelers => _driver.FindElement(By.CssSelector("#traveler-selector-hp-flight>div>ul>li>button"));

        private IWebElement TravelerAddLink => _driver.FindElement(By.XPath("//div[@class='traveler-selector-sinlge-room-data traveler-selector-room-data']/div/div[4]/button"));

        private IWebElement TravelerCount => _driver.FindElement(By.XPath("//div[@class='traveler-selector-sinlge-room-data traveler-selector-room-data']/div/div[3]/span"));

        private IWebElement AddFlightsBtn => _driver.FindElement(By.CssSelector("#add-flight-leg-hp-flight"));

        private IWebElement SearchBtn => _driver.FindElement(By.CssSelector("#gcw-flights-form-hp-flight>div.cols-nested.ab25184-submit>label>button"));

        private IList<IWebElement> CityDropDownList => _driver.FindElements(By.CssSelector("div.autocomplete-dropdown>ul>div>li"));

        #endregion

        #region Methods

        public void ClickFlightTab()
        {
            FlightsTab.Click();
        }

        public void ClickMutiCityTab()
        {
            MultiCityTab.Click();
        }

        public void ClickFlyFrom1(string city)
        {
            UtilMethods.EnterData(FlyFrom1,city);
            CityDropDownList.SelectFromList(city);
        }

        public void ClickFlyTo1(string city)
        {
            UtilMethods.EnterData(GoingTo1,city);
            CityDropDownList.SelectFromList(city);
        }

        public void ClickFlyFrom2(string city)
        {
            UtilMethods.EnterData(FlyFrom2, city);
            CityDropDownList.SelectFromList(city);
        }

        public void ClickFlyTo2(string city)
        {
            UtilMethods.EnterData(GoingTo2, city);
            CityDropDownList.SelectFromList(city);
        }

        public void EnterDepartingDate1(string dateValue)
        {
            UtilMethods.EnterData(DepartingDate1, dateValue);
            CloseCalendar.Click();
        }

        public void AddTravelers(string number, TimeSpan timeout)
        {
            var watch = Stopwatch.StartNew();
            if (Travelers.IsElementEnabled(Wait(2)))
            {
                Travelers.Click();
                do
                {
                    TravelerAddLink.Click();
                    Wait(1);

                    if (TravelerCount.GetText().Equals(number))
                        break;

                } while (watch.Elapsed<=timeout);
            }
            if (TravelerAddLink.IsElementVisible(Wait(1)))
            {
                Travelers.Click();
                Wait(1);
            }
        }

        public void EnterDepartingDate2(string dateValue)
        {
            UtilMethods.EnterData(DepartingDate2, dateValue);
            CloseCalendar.Click();
        }

        public void ClickSearchBtn()
        {
            if (SearchBtn.IsElementEnabled(Wait(2)))
            {
                SearchBtn.ClickBtn(_driver);
            }
        }

        #endregion
    }
}
