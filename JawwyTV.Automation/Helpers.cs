using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JawwyTV.Automation
{
    public static class  Helpers
    {
        public static NLog.Logger Logger
        {
            get
            {
                NLog.LogManager.Configuration.Variables["LogsDirectory"] = TestContext.

                return NLog.LogManager.GetCurrentClassLogger();
            }
        }



    }
}
