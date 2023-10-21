using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace JawwyTV.Automation.Browser
{
    public static class Driver
    {
        private static IWebDriver s_driver;
        public static IWebDriver Current
        {
            get
            {
                return s_driver ?? throw new Exception("Driver is null.");
            }
        }
        public static WebDriverWait DriverWait;
        public enum BrowserType
        {
            Chrome,
            Edge
        }
        public static void SetDriver(BrowserType browser,string resolutions, int waitTimeInSeconds=120)
        {
            switch(browser)
            {
                case BrowserType.Chrome:
                    SetChromeDriver(resolutions, waitTimeInSeconds);
                    break;
                case BrowserType.Edge:
                    SetEdgeDriver(resolutions);
                    break;
                default:
                    throw new ArgumentException($"{browser} is not supported");
            }
        }
        private static void SetChromeDriver (string res,int timeoutSeconds)
        {
            var options = new ChromeOptions();
            options.AddArgument($"--window-size={res}");
            options.AddArgument("--enable-automation");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-infobars");
            options.AddArgument("--disable-notifications");
            s_driver = new ChromeDriver(options);
            DriverWait = new WebDriverWait(s_driver, TimeSpan.FromSeconds(timeoutSeconds));
        }
        private static void SetEdgeDriver(string res)
        {
            var options = new EdgeOptions();
            options.AddArgument($"--window-size={res}");
            options.AddArgument("--enable-automation");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-infobars");
            options.AddArgument("--disable-notifications");
            s_driver = new EdgeDriver(options);
        }
        public static void Goto(this IWebDriver driver, string url) 
        {
            driver.Navigate().GoToUrl(url);
        }

    }
}

