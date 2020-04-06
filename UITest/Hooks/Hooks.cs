using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestProject.UITest.Driver;

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
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
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
