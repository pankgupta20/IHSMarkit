using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;
using TechTalk.SpecFlow;
using TestProject.UITest.Driver;
using TestProject.UITest.Utilities;

namespace TestProject.UITest.Base
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        private static DriverFactory _driverFactory;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario("Web")]
        public void SetUp()
        {
            _driverFactory = new DriverFactory();
            _driver = _driverFactory.CreateDriver();
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromMilliseconds(ConfigFile.PageLoadTimeout);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(ConfigFile.DefaultTimeout);
            _driver.Manage().Window.Maximize();
            _objectContainer.RegisterInstanceAs(_driver);
        }

        [AfterScenario("Web")]
        public void CleanUp(ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError != null)
            {
                _driver.TakeScreenshot().SaveAsFile(Path.Combine("..", "..", "TestResults", $"{scenarioContext.ScenarioInfo.Title}.png"), ScreenshotImageFormat.Png);
            }
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}
