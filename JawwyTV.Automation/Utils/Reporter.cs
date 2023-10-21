using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace JawwyTV.Automation.Utils
{
    public static class Reporter
    {
        private static ExtentReports s_extentReporter;
        private static ExtentTest s_test;
        private static ExtentSparkReporter s_sparkReporter;
        public static void Setup()
        {
            s_extentReporter = new ExtentReports();
            s_sparkReporter = new ExtentSparkReporter($"{TestContext.CurrentContext.TestDirectory}\\Reports\\report.html");
            s_extentReporter.AttachReporter(s_sparkReporter);
        }
        public static void CreateTest()
        {
            s_test = s_extentReporter.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        public static void AddResultsToReport()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    s_test.Log(Status.Fail, "Test Status is :" + Status.Fail + " With Error: " + errorMessage);
                    break;
                default:
                    s_test.Log(Status.Pass, "Test Status is : " + Status.Pass);
                    break;
            }

        }
        public static void EndReport()
        {
            s_extentReporter.Flush();
        }
    }
}

