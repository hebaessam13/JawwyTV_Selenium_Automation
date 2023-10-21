using NUnit.Framework;
using static JawwyTV.Automation.Browser.Driver;
using JawwyTV.Automation.Test.Utils;
using JawwyTV.Automation.Pages;
using JawwyTV.Automation.Test.Models;
using JawwyTV.Automation.Utils;

namespace JawwyTV.Automation.Test.Tests
{
    public class TestPlans : TestBase
    {
        public TestPlans(BrowserType type, string resolution) : base(type, resolution)
        {

        }
        [TestCaseSource(typeof(DataHelper), nameof(DataHelper.ExpectedSubscriptionPlans))]
        public void Subscription_Plans_ValidPlansDetails(SubscriptionPlan expectedplansDetails)
        {
            DashboardPage.GoToAppPerferences().ChooseCountry(expectedplansDetails.Country);
            PlansPage plansPage= DashboardPage.GoToSubscriptionPlans();
            Assert.Multiple(() =>
            {
                Assertion.CheckListsAreEqual(expectedplansDetails.Plans.Prices, plansPage.GetPlansPrices());
                Assertion.CheckListsAreEqual(expectedplansDetails.Plans.Currencies, plansPage.GetPricesCurrency());
                Assertion.CheckListsAreEqual(expectedplansDetails.Plans.Types, plansPage.GetPlantypes());
            });
            
        }

        
    }
}

