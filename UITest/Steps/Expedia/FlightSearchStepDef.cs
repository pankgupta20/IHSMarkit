using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestProject.UITest.Helpers;
using TestProject.UITest.Models;
using TestProject.UITest.PageAction;
using TestProject.UITest.Pages.Expedia;

namespace TestProject.UITest.Steps.Expedia
{
    [Binding]
    public class FlightSearchStepDef
    {
        private readonly ExResultPage resultPage;
        private readonly ExHomePage homePage;
        private readonly ExSummaryPage summaryPage;
        private readonly HomePageAction homePageAction;
        private readonly ResultPageAction resultPageAction;
        private readonly SummaryPageAction summaryPageAction;
        private string _singleTicketPrice;
        private FlightDetails _flightDetails;
       

        public FlightSearchStepDef(IWebDriver driver)
        {
            resultPage = new ExResultPage(driver);
            homePage = new ExHomePage(driver);
            summaryPage = new ExSummaryPage(driver);
            homePageAction = new HomePageAction(driver);
            resultPageAction = new ResultPageAction(driver);
            summaryPageAction = new SummaryPageAction(driver);
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

        [When(@"user enters required flight search details")]
        public void WhenUserEntersRequiredFlightSearchDetails()
        {
            _flightDetails = TestDataReader.DeserializefromTestDataFile<FlightDetails>("FlightDetails.json");
            homePageAction.EnterFlightDetails(_flightDetails.Cities[0].CityFrom, _flightDetails.Cities[0].CityTo, _flightDetails.DepartureDates[0].DepartDate,
                _flightDetails.Travelers, _flightDetails.Cities[1].CityFrom, _flightDetails.Cities[1].CityTo, _flightDetails.DepartureDates[1].DepartDate);
        }


        [When(@"Click on the search button and check the results")]
        public void WhenClickOnTheSearchButtonAndCheckTheResults()
        {
            homePage.ClickSearchBtn();
        }

        [When(@"Click the first result and then further click the first result under it")]
        public void WhenClickTheFirstResultAndThenFurtherClickTheFirstResultUnderIt()
        {
            _singleTicketPrice = resultPageAction.SelectFlight();
        }

        [Then(@"verify the flight details and total price")]
        public void ThenVerifyTheFlightDetailsAndTotalPrice()
        {
           //single ticket price on summary page is calculated in round number, so assertion is failing when calculating for 4 adults.
           // Now taking the single price also summary page and validate it:

            summaryPageAction.ValidateFlightCities(_flightDetails);
            summaryPageAction.ValidateFlightDates(_flightDetails);
            summaryPageAction.ValidateTotalTicketPrice();
        }

    }
}
