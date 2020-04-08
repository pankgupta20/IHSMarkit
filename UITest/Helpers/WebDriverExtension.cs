using OpenQA.Selenium;
using System;
using System.Linq;

namespace TestProject.UITest.Utilities
{
    public static class WebDriverExtension
    {
        public static void SwitchToLastWindow(this IWebDriver driver)
        {
            try
            {
                var availableWindows = driver.WindowHandles;

                if (availableWindows.Count > 1)
                {
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                }
            }catch(Exception ex)
            {
                throw new Exception("No new window exist- "+ex.Message);
            }
        }

    }
}
