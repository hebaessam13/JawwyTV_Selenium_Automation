using System.Collections.Generic;
using JawwyTV.Automation.Test.Models;
using JawwyTV.Automation.Utils;

namespace JawwyTV.Automation.Test.Utils
{
    public static class DataHelper
    {
        public static List<SubscriptionPlan> ExpectedSubscriptionPlans
        {
            get
            {
                return HelperMethods.LoadJson<List<SubscriptionPlan>>("SubscriptionPlans.json");
            }
        }

    }
}

