using NUnit.Framework;
using JawwyTV.Automation.Browser;
using static JawwyTV.Automation.Browser.Driver;
using static JawwyTV.Automation.Utils.HelperMethods;
using JawwyTV.Automation.Utils;

namespace JawwyTV.Automation.Test.Utils
{
    [TestFixture(BrowserType.Chrome, Resolutions.MostCommonRes)]
    [TestFixture(BrowserType.Edge, Resolutions.MostCommonRes)]
    public class TestBase
    {
        BrowserType _browserType;
        string _resolution;
        public TestBase(BrowserType type, string resolution)
        {
            _browserType = type;
            _resolution = resolution;
        }

        [SetUp]
        public void TestIntialize()
        {
            Log.Info($"------------------STARTING NEW TEST :{TestContext.CurrentContext.Test.Name} ------------------");
            Reporter.CreateTest();
            Driver.SetDriver(_browserType, _resolution);
            Driver.Current.Goto(TestContext.Parameters["BaseUrl"]);
        }
        [TearDown]
        public void CleanUp()
        {
            Reporter.AddResultsToReport();
            Driver.Current.Quit();
        }
        [OneTimeSetUp]
        public void Setup()
        {
            Reporter.Setup();
        }
        [OneTimeTearDown]
        public void AllTestsCleanUp()
        {
            NLog.LogManager.Shutdown();
            Reporter.EndReport();
        }
    }
}

