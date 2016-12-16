using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecDrill.Infrastructure;
using SpecDrill.Infrastructure.Configuration;
using SpecDrill.Infrastructure.Logging.Interfaces;
using SpecDrill.SecondaryPorts.AutomationFramework.Core;
using System;
using System.Diagnostics;

namespace SpecDrill.MsTest
{
    public class TestBase
    {
        protected ILogger Log =  Infrastructure.Logging.Log.Get<TestBase>();
        protected readonly IBrowser Browser;
        public TestBase()
        {
            try
            {
                Browser = new Browser(ConfigurationManager.Settings);
            }
            catch (Exception e)
            {
                Trace.Write($"TestBase. -> {e}");
            }
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
