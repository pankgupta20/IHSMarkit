using OpenQA.Selenium;
using System;
using TestProject.UITest.Pages.Expedia;

namespace TestProject.UITest.PageAction
{
    public class HomePageAction
    {
        private readonly ExHomePage homePage;

        public HomePageAction(IWebDriver driver)
        {
            homePage = new ExHomePage(driver);
        }

        public void EnterFlightDetails(string flyfrom1, string flyto1, string departdate1, string travelers, string flyfrom2, string flyto2, string departdate2)
        {
            homePage.ClickFlyFrom1(flyfrom1);
            homePage.ClickFlyTo1(flyto1);
            homePage.EnterDepartingDate1(departdate1);
            homePage.AddTravelers(travelers, TimeSpan.FromSeconds(60));
            homePage.ClickFlyFrom2(flyfrom2);
            homePage.ClickFlyTo2(flyto2);
            homePage.EnterDepartingDate2(departdate2);
        }

    }
}
