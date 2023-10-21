using System.Collections.Generic;

namespace JawwyTV.Automation.Test.Models
{
    public class SubscriptionPlan
    {
        public string Country { get; set; }
        public PlansDetails Plans { get; set; }
    }
    public class PlansDetails
    {
        public List<string> Types { get; set; }
        public List<string> Prices { get; set; }
        public List<string> Currencies { get; set; }
    }
}

