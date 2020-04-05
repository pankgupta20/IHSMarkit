﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace TestProject.UITest.Driver
{
    public class DriverFactory
    {
        public IWebDriver CreateDriver()
        {
            string browser = Environment.GetEnvironmentVariable("BROWSER") ?? "CHROME";

            switch (browser.ToUpperInvariant())
            {
                case "CHROME":
                    return new ChromeDriver();
                case "FIREFOX":
                    return new FirefoxDriver();
                case "IE":
                    return new InternetExplorerDriver();
                default:
                    throw new ArgumentException($"Browser not yet implemented: {browser}");
            }
        }
    }
}
