using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TestProject.UITest.Models;
using TestProject.UITest.Pages.Expedia;

namespace TestProject.UITest.PageAction
{
    public class SummaryPageAction
    {
        private readonly ExSummaryPage summaryPage;

        public SummaryPageAction(IWebDriver driver)
        {
            summaryPage = new ExSummaryPage(driver);
        }

        public void ValidateFlightDates(FlightDetails flightDetails)
        {
            for (int i = 0; i < flightDetails.Cities.Count; i++)
            {
                var actualDate = "";
                var expDate = flightDetails.DepartureDates[i].DepartDate;
                DateTime dt = DateTime.Parse(expDate);
                string monthValue = dt.ToString("MMMM");
                string dateValue = dt.Day.ToString();
                string dayOfWeek = dt.DayOfWeek.ToString().Substring(0, 3);
                string date = dayOfWeek+ ", "+monthValue + " " + dateValue;

                actualDate = i > 0 ? summaryPage.GetReturnDate() : summaryPage.GetDepartDate();
                Assert.IsTrue(actualDate.Contains(date), $"Expected date: {date} is not equal to Actual date: {actualDate}");
            }
        }

        public void ValidateFlightCities(FlightDetails flightDetails)
        {
            for(int i = 0; i < flightDetails.Cities.Count; i++)
            {
                IList<IWebElement> elementList = null;
                var cityFrom = flightDetails.Cities[i].CityFrom.Substring(0, 3).ToUpper() ;
                var cityTo = flightDetails.Cities[i].CityTo.Substring(0, 3).ToUpper();

                elementList = i>0? summaryPage.GetReturnCityList(): summaryPage.GetDepartCityList();

                var actualCityFrom = summaryPage.GetCityCode(elementList, 1);
                Assert.IsTrue(actualCityFrom.Contains(cityFrom), $"Expected city: {cityFrom} is not present on booking section");

                var actualCityTo = summaryPage.GetCityCode(elementList, 3);
                Assert.IsTrue(actualCityTo.Contains(cityTo), $"Expected city: {cityTo} is not present on booking section");
            }
        }

        public void ValidateTotalTicketPrice()
        {
            var TotalTicketsPrice = summaryPage.GetTotalPrice().Substring(1);
            var expectedTotalTicketPrice = Convert.ToDecimal(summaryPage.GetSingleTicketPrice()) * 4;
            Assert.AreEqual(expectedTotalTicketPrice.ToString(), TotalTicketsPrice, $"Expected total ticket price: {expectedTotalTicketPrice} is not equal to actual: {TotalTicketsPrice}");
        }
    }
}
