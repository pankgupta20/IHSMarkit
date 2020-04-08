using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;
using TestProject.UITest.Pages;
using TestProject.UITest.Utilities;

namespace TestProject.UITest.Steps
{
    [Binding]
    public class UserLoginStepDef
    {
        private readonly LoginPage loginPage;
        private readonly HomePage homePage;

        public UserLoginStepDef(IWebDriver driver)
        {
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
        }

        [Given(@"User is at Home page")]
        public void GivenUserIsAtHomePage()
        {
            homePage.OpenUrl(homePage.AutomationPracticeUrl);
        }

        [Given(@"navigates to Login Page")]
        public void GivenNavigatesToLoginPage()
        {
            homePage.ClickSignin();
        }

        [When(@"user enters (.*) and (.*)")]
        public void WhenUserEntersAnd(string username, string password)
        {
            loginPage.Login(username, password);
        }

        [When(@"Click on the Signin button")]
        public void WhenClickOnTheSigninButton()
        {
            loginPage.Submit();
            Thread.Sleep(1000);
        }

        [Then(@"correct error message (.*) should be displayed")]
        public void ThenCorrectErrorMessageShouldBeDisplayed(string expMessage)
        {
            var errorText = loginPage.GetErrorMessage();
            Assert.AreEqual(expMessage, errorText, "Exepcted text is not equal to Actual text");
        }

    }
}
