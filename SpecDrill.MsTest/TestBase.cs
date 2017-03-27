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
        protected static ILogger Log =  Infrastructure.Logging.Log.Get<TestBase>();
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
        [ClassInitialize]
        public static void __ClassSetUp()
        {
            try
            {
                ClassSetUp();
            }
            catch (Exception e)
            {
                Log.Log(LogLevel.Error, $"Failed in TestInitialize for {TestContext.TestName} with {e}");
            }
        }
        protected static Action ClassSetUp = () => { };


        [ClassCleanup]
        public static void __ClassCleanup()
        {
            ClassCleanUp();
        }
        protected static Action ClassCleanUp = () => { };


        [TestInitialize]
        public void _TestSetUp()
        {
            try
            {
                TestSetUp();
            }
            catch (Exception e)
            {
                Log.Log(LogLevel.Error, $"Failed in TestInitialize for {TestContext.TestName} with {e}");
            }
        }

        public TestContext TestContext { get; set; }

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
