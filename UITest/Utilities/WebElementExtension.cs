using OpenQA.Selenium;
using System;
using System.Threading;

namespace TestProject.UITest.Utilities
{
    public static class WebElementExtension
    {
        public static string GetText(this IWebElement element)
        {
            int retry = 1;
            string text = null;
            do
            {
                try
                {
                    if(element.Displayed)
                    {
                        text = element.Text;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    retry = retry + 1;
                    if (retry > 3)
                        Console.WriteLine(ex.Message);
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
                    if (retry > 3) Console.WriteLine(ex.Message);
                }
            } while (retry <= 3);
        }
    }
}
