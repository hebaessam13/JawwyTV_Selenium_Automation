using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace JawwyTV.Automation.Browser
{
    public static class Extensions
    {
        public static void ScrollTo(this IWebDriver driver, IWebElement element) 
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public static WebDriverWait Wait(this IWebDriver driver) {
            return Driver.DriverWait;

        }
    }
}

