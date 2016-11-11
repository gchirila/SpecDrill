using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecDrill.Infrastructure;
using SpecDrill.Infrastructure.Configuration;
using SpecDrill.Infrastructure.Logging.Interfaces;
using SpecDrill.SecondaryPorts.AutomationFramework.Core;

namespace SpecDrill.MsTest
{
    public class TestBase
    {
        protected ILogger Log =  Infrastructure.Logging.Log.Get<TestBase>();
        protected readonly IBrowser Browser;
        public TestBase()
        {
            Browser = new Browser(ConfigurationManager.Settings);
        }

        [TestInitialize]
        public void _TestSetUp()
        {
            TestSetUp();
        }

        [TestCleanup]
        public void _TestTearDown()
        {
            TestTearDown();
        }

        public virtual void TestSetUp()
        {
        }

        public virtual void TestTearDown()
        {
            Browser.Exit();
        }
    }
}
