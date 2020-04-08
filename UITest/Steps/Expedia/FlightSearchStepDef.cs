using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestProject.UITest.PageAction;
using TestProject.UITest.Pages.Expedia;
using TestProject.UITest.Utilities;

namespace TestProject.UITest.Steps.Expedia
{
    [Binding]
    public class FlightSearchStepDef
    {
        private readonly ExResultPage resultPage;
        private readonly ExHomePage homePage;
        private readonly ExSummaryPage summaryPage;
        private readonly HomePageAction homePageAction;

        public FlightSearchStepDef(IWebDriver driver)
        {
            resultPage = new ExResultPage(driver);
            homePage = new ExHomePage(driver);
            summaryPage = new ExSummaryPage(driver);
            homePageAction = new HomePageAction(driver);
        }

        [Given(@"User is at Flight Search page")]
        public void GivenUserIsAtFlightSearchPage()
        {
            homePage.OpenUrl(homePage.ExpediaUrl);
        }

        [Given(@"clicked on Flights and multicity tab")]
        public void GivenClickedOnFlightsAndMulticityTab()
        {
            homePage.ClickFlightTab();
            homePage.ClickMutiCityTab();
        }

        [When(@"user enters required details '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void WhenUserEntersRequiredDetails(string flyfrom1, string flyto1, string departdate1, string travelers, string flyfrom2, string flyto2, string departdate2)
        {
            homePageAction.EnterFlightDetails(flyfrom1,flyto1,departdate1,travelers,flyfrom2,flyto2,departdate2);
        }

        [When(@"Click on the search button and check the results")]
        public void WhenClickOnTheSearchButtonAndCheckTheResults()
        {
            homePage.ClickSearchBtn();
        }

        [When(@"Click the first result and then further click the first result under it")]
        public void WhenClickTheFirstResultAndThenFurtherClickTheFirstResultUnderIt()
        {
            resultPage.ClickSelectBtn();
            var SingleTicketPrice = resultPage.GetSingleTicketPrice();
            resultPage.ClickSelectBtn();
        }

        [Then(@"verify the flight details and total price")]
        public void ThenVerifyTheFlightDetailsAndTotalPrice()
        {
            var TotalTicketsPrice = summaryPage.GetTotalPrice();

        }

    }
}
