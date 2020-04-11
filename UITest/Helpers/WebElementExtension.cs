using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace TestProject.UITest.Utilities
{
    public static class WebElementExtension
    {
        public static string GetText(this IWebElement element)
        {
            int retry = 1;
            string text = "";
            do
            {
                try
                {
                    if (element.Displayed)
                    {
                        text = element.Text;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    retry = retry + 1;
                    if (retry > 3)
                        Logger.WriteError(ex.Message);
                }
            } while (retry <= 3);

            return text;
        }

        public static void SendInput(this IWebElement element, string input, TimeSpan timeOut)
        {
            int retry = 1;
            do
            {
                try
                {
                    if (element.Enabled)
                    {
                        element.SendKeys(input);
                        Thread.Sleep(timeOut);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    retry = retry + 1;
                    if (retry > 3) Logger.WriteError(ex.Message);
                }
            } while (retry <= 3);
        }

        public static void SelectByText(this IWebElement element, string text, IWebDriver driver = null)
        {
            int retry = 1;
            do
            {
                try
                {
                    element.IsElementVisible(TimeSpan.FromMilliseconds(ConfigFile.Timeout));
                    if (driver != null)
                        element.ScrollToView(driver);
                    SelectElement selectEle = new SelectElement(element);
                    DefaultWait<SelectElement> wait = new DefaultWait<SelectElement>(selectEle)
                    {
                        Timeout = TimeSpan.FromSeconds(10)
                    };
                    wait.Until<bool>(exist =>
                    {
                        if (selectEle.Options.Count >= 2)
                            return true;
                        else
                            return false;
                    }
                    );
                    selectEle.SelectByText(text);
                    break;
                }
                catch (Exception ex)
                {
                    retry = retry + 1;
                    if (retry > 3) Logger.WriteError(ex.Message);
                }
            } while (retry <= 3);
        }

        public static bool IsElementVisible(this IWebElement el, TimeSpan timeout)
        {
            var elementIsVisible = false;
            var watch = Stopwatch.StartNew();

            do
            {
                try
                {
                    if (el.Displayed)
                    {
                        elementIsVisible = true;
                        break;
                    }
                }
                catch (Exception)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(ConfigFile.ShortTimeout));
                }
            }
            while (watch.Elapsed <= timeout);

            return elementIsVisible;
        }

        public static void ScrollToView(this IWebElement element, IWebDriver driver)
        {
            var js = driver as IJavaScriptExecutor;

            js?.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static bool IsElementEnabled(this IWebElement element, TimeSpan timeout)
        {
            var elementIsEnabled = false;
            var watch = Stopwatch.StartNew();

            do
            {
                if (element.Enabled)
                {
                    elementIsEnabled = true;
                    break;
                }

                Thread.Sleep(1000);
            }
            while (watch.Elapsed <= timeout);

            return elementIsEnabled;
        }

        public static void WaitUntilElementPresent(this IWebElement element, TimeSpan timeOut)
        {
            Stopwatch watch = Stopwatch.StartNew();

            while (watch.Elapsed <= timeOut)
            {
                if (element.IsElementVisible(TimeSpan.FromMilliseconds(ConfigFile.ShortTimeout)))
                    break;
            }
        }

        public static IWebElement SelectFromListWithGivenText(this IList<IWebElement> elements, string text)
        {
            return elements.FirstOrDefault(i => i.Text.Contains(text));
        }

        public static IWebElement SelectVisibleElementFromList(this IList<IWebElement> elements)
        {
            return elements.FirstOrDefault(i => i.IsElementVisible(TimeSpan.FromMilliseconds(ConfigFile.ShortTimeout)));
        }

        public static void ClickBtn(this IWebElement element, IWebDriver driver)
        {
            try
            {
                if (element.IsElementEnabled(TimeSpan.FromMilliseconds(ConfigFile.Timeout)))
                {
                    element.Click();
                    UtilMethods.WaitForPageLoaded(driver, Convert.ToInt32(ConfigFile.PageLoadTimeout));
                }
            }
            catch (Exception ex)
            {
                Logger.WriteError(ex.StackTrace);
            }
        }

        public static void WaitForElementsToLoad(this IList<IWebElement> elementsList, int timeOut = 20000)
        {
            Stopwatch watch = Stopwatch.StartNew();
            TimeSpan timeOutInSec = TimeSpan.FromMilliseconds(timeOut);
            do
            {
                int elementsCount = elementsList.Count;
                if (elementsCount > 0 && elementsList[elementsCount - 1].IsElementVisible(TimeSpan.FromMilliseconds(ConfigFile.Timeout)))
                    break;
            } while (watch.Elapsed <= timeOutInSec);
        }

        public static void WaitForElementLoadTillTextDisplayed(this IWebElement element,int timeOut = 60)
        {
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element)
            {
                Timeout = TimeSpan.FromSeconds(timeOut),
                PollingInterval = TimeSpan.FromMilliseconds(ConfigFile.PollingInterval),
            };

            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement ele) =>
            {
                string elementText = element.Text;
                if (elementText.Length>0)
                {
                    return true;
                }
                Logger.WriteInfo($"element is not displayed: {elementText}");
                return false;
            });
            wait.Until(waiter);
        }

        public static bool WaitForElementAttribute(this IWebElement element, string value)
        {
            bool result = false;
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element)
            {
                Timeout = TimeSpan.FromMilliseconds(ConfigFile.ShortTimeout),
                PollingInterval = TimeSpan.FromMilliseconds(ConfigFile.PollingInterval)
            };

            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement ele) =>
            {
                string styleAttrib = element.GetAttribute("style");
                if (styleAttrib.Contains(value))
                {
                   return result = true;
                }
                Console.WriteLine("Percentage is still " + styleAttrib);
                return result;
            });
            wait.Until(waiter);
            return result;
        }
    }
}
