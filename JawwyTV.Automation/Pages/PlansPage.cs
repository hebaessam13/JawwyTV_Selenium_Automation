using JawwyTV.Automation.Browser;
using OpenQA.Selenium;
using System.Collections.Generic;
using static JawwyTV.Automation.Utils.HelperMethods;

namespace JawwyTV.Automation.Pages
{
    public class PlansPage
    {
        public PlansPage()
        {
            Driver.Current.ScrollTo(_plansTable);

        }
        public static PlansPage GoTo()
        {
            return new PlansPage();
        }

        #region  Page elements
        private IWebElement _plansTable
        {
            get
            {
                return Driver.Current.FindElement(By.ClassName("plan-section"));
            }
        }
       
        private IEnumerable<IWebElement> _pricesElements
        {
            get
            {
                return Driver.Current.FindElements(By.XPath("//div[@class='plan-names']//div[@class='price']"));
            }
        }
        private IEnumerable<IWebElement> _plantypesElements
        {
            get
            {
                return Driver.Current.FindElements(By.XPath("//div[@class='plan-names']//strong"));
            }
        }
        #endregion

        #region Methods to interact with page elements
        public List<string> GetPlansPrices()
        {
            Log.Info("Getting Plans Prices");
            List<string> prices = new List<string>();
            foreach(var element in _pricesElements)
            {
                prices.Add(element.FindElement(By.TagName("b")).Text);
            }
            return prices;
        }
        public List<string> GetPricesCurrency()
        {
            Log.Info("Getting Plans Prices currency");
            List<string> currencies = new List<string>();
            foreach (var element in _pricesElements)
            {
               currencies.Add(element.FindElement(By.TagName("i")).Text);
            }
            return currencies;
        }
        public List<string> GetPlantypes()
        {
            Log.Info("Getting Plans types");
            List<string> types = new List<string>();
            foreach (var element in _plantypesElements)
            {
                types.Add(element.Text);
            }
            return types;
        }
        #endregion

    }
}

