using static JawwyTV.Automation.Utils.HelperMethods;

namespace JawwyTV.Automation.Pages
{
    public class DashboardPage
    {
        public static HeaderPage GoToAppPerferences()
        {
            Log.Info("Go to App Perferences");
            return new HeaderPage();
        }
        public static PlansPage GoToSubscriptionPlans()
        {
            return new PlansPage();
        }
    }
}

