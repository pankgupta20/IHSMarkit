using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
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

        public static void CloseExtraWindows(this IWebDriver driver)
        {
            string parentWindow = driver.CurrentWindowHandle;
            try
            {
                var availableWindows = driver.WindowHandles;

                if (availableWindows.Count > 1)
                {
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    driver.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteInfo(ex.Message);
            }
            finally
            {
                driver.SwitchTo().Window(parentWindow);
            }
        }

        public static string GetElementTextAtGivenIndex(this IWebDriver driver, IList<IWebElement> elementsList, int index)
        {
            try
            {
                return elementsList.ElementAt(index).GetText();
            }catch(Exception ex)
            {
                Logger.WriteError(ex.Message);
            }
            return null;
        }

        public static IWebElement GetElementFromActivePage(this IWebDriver driver, By by, double timeoutSeconds = 30)
        {
            IWebElement element = null;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(WebDriverTimeoutException), typeof(UnhandledAlertException));
            try
            {
                element = wait.Until(drv =>
                {
                    try
                    {
                        return drv.FindElement(by);
                    }
                    catch (NoSuchElementException ex)
                    {
                        Logger.WriteError(ex.StackTrace);
                        return null;
                    }
                });
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.WriteError(ex.StackTrace);
                return null;
            }
            return element;
        }

        public static IList<IWebElement> GetElementListFromActivePage(this IWebDriver driver, By by, double timeoutSeconds = 30)
        {
            IList<IWebElement> elementList = null;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(WebDriverTimeoutException), typeof(UnhandledAlertException));
            try
            {
                elementList = wait.Until(drv =>
                {
                    try
                    {
                        return drv.FindElements(by);
                    }
                    catch (NoSuchElementException ex)
                    {
                        Logger.WriteError(ex.StackTrace);
                        return null;
                    }
                });
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.WriteError(ex.StackTrace);
                return null;
            }
            return elementList;
        }
     }
}
