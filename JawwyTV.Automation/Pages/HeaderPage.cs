using JawwyTV.Automation.Browser;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using static JawwyTV.Automation.Utils.HelperMethods;


namespace JawwyTV.Automation.Pages
{
    public class HeaderPage
    {
        public static HeaderPage GoTo()
        {
            return new HeaderPage();
        }

        #region Page elements
        private IWebElement _countryLink;

        public IWebElement ChangeCountryBtn
        {
            get
            {
                return Driver.Current.FindElement(By.Id("country-btn"));
            }
        }
        public string CurrentSelectedCountry
        {
            get
            {
                return Driver.Current.FindElement(By.XPath("//div[@class='country-current']//*[@id='country-name']")).Text;
            }
        }
        #endregion

        #region Methods to interact with Page elements
       
        private IWebElement GetElementForCountry(string country)
        {
            switch (country)
            {
                case "Egypt":
                    _countryLink = Driver.Current.FindElement(By.Id("eg"));
                    break;
                case "UAE":
                    _countryLink = Driver.Current.FindElement(By.Id("ae"));
                    break;
                case "Algeria":
                    _countryLink = Driver.Current.FindElement(By.Id("dz"));
                    break;
                default:
                    throw new ArgumentException($"{country} doesn't exist");

            }
            return _countryLink;
        }
      
        public HeaderPage OpenCountriesOption()
        {
            ChangeCountryBtn.Click();
            return this;

        }
        public HeaderPage SelectCountry(string country)
        {
            GetElementForCountry(country).Click();
            return this;
        }
        #endregion

        #region Actions
        public HeaderPage ChooseCountry(string country)
        {
            Log.Info($"Changing Country to {country}");
            OpenCountriesOption();
            GetElementForCountry(country).Click();
            Log.Info("Asserting Country has been updated");
            Assert.That(CurrentSelectedCountry.Contains(country.ToString()));
            return this;
        }
        #endregion


    }
}

