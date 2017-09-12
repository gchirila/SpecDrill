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
                Log.Log(LogLevel.Error, e.Message);
                Trace.Write($"TestBase. -> {e}");
                if (Browser != null)
                    Browser.Exit();
            }
        }
        [ClassInitialize]
        public static void _ClassSetup()
        {
            try
            {
                ClassSetup();
            }
            catch (Exception e)
            {
                Log.Log(LogLevel.Error, $"Failed in ClassInitialize with {e}");
            }
        }
        protected static Action ClassSetup = () => { };


        [ClassCleanup]
        public static void _ClassCleanup()
        {
            ClassCleanup();
        }
        protected static Action ClassCleanup = () => { };


        [TestInitialize]
        public void _TestSetup()
        {
            try
            {
                TestSetup();
            }
            catch (Exception e)
            {
                Log.Log(LogLevel.Error, $"Failed in TestInitialize for {TestContext.TestName} with {e}");
            }
        }

        public TestContext TestContext { get; set; }

        [TestCleanup]
        public void _TestCleanup()
        {
            TestCleanup();
        }

        public virtual void TestSetup()
        {
        }

        public virtual void TestCleanup()
        {
            if (Browser != null)
                Browser.Exit();
        }
    }
}
