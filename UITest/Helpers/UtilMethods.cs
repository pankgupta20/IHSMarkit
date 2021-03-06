﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject.UITest.Utilities
{
    public static class UtilMethods
    {
        public static void EnterDataAndSelectFromList(IWebElement element, IList<IWebElement> cityList, string city, IWebDriver driver)
        {
            if (element.IsElementEnabled(TimeSpan.FromMilliseconds(ConfigFile.ShortTimeout)))
            {
                element.SendInput(city, TimeSpan.FromMilliseconds(ConfigFile.ShortTimeout));
                cityList.SelectFromListWithGivenText(city).ClickBtn(driver);
            }
        }

        public static void ClickButton(IWebElement element, IWebDriver driver)
        {
            if (element.IsElementVisible(TimeSpan.FromMilliseconds(ConfigFile.ShortTimeout)))
            {
                element.ClickBtn(driver);
            }
        }

        public static void EnterData(IWebElement element,string data)
        {
            if (element.IsElementVisible(TimeSpan.FromMilliseconds(ConfigFile.ShortTimeout)))
            {
                element.SendInput(data,TimeSpan.FromMilliseconds(ConfigFile.ShortTimeout));
            }
        }

        public static IWebElement SelectFirstElementFromList(IList<IWebElement> elements)
        {
            try
            {
                if (elements.Count > 0)
                    return elements.FirstOrDefault();
            }
            catch (Exception e)
            {
                Logger.WriteError(e.StackTrace);
            }
            return null;
        }

        public static void WaitForPageLoaded(IWebDriver driver,int timeout)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            for (int retry = 1; retry <= 3; retry++)
            {
                try
                {
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                    if ((bool)executor.ExecuteScript("return window.jQuery != undefined"))
                    {
                        wait.Until((d) => (bool)executor.ExecuteScript("return jQuery.active == 0 && document.readyState == 'complete'"));
                        break;
                    }
                }
                catch (Exception ex)
                {
                    if (retry == 3) Logger.WriteError(ex.Message);
                }
            }
        }
    }
}
