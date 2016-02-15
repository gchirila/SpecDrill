using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecDrill.Adapters.WebDriver;
using SpecDrill.Infrastructure.Configuration;
using SpecDrill.Infrastructure.Logging.Interfaces;

namespace SpecDrill
{
    public class TestBase
    {
        protected ILogger Log =  Infrastructure.Logging.Log.Get<TestBase>();

        protected Browser Browser = new Browser(ConfigurationManager.Settings);

        static TestBase()
        {
            

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
            Browser.Exit();
        }

        public virtual void TestSetUp()
        {
        }

        public virtual void TestTearDown()
        {
        }
    }
}
