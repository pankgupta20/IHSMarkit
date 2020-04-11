using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.UITest.Pages.Expedia;
using TestProject.UITest.Utilities;

namespace TestProject.UITest.PageAction
{
    public class ResultPageAction
    {
        private readonly ExResultPage resultPage;

        public ResultPageAction(IWebDriver driver)
        {
            resultPage = new ExResultPage(driver);
        }

        public string SelectFlight()
        {
            resultPage.ClickSelectBtn();
            var SingleTicketPrice = resultPage.GetSingleTicketPrice();
            resultPage.ClickSelectBtn();
            return SingleTicketPrice;
        }
    }
}
