using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using OpenQA.Selenium;
using SpecDrill.Adapters.WebDriver;
using SpecDrill.Configuration;

namespace SpecDrill
{
    public class TestBase
    {
        //TODO: Waits
        // Wait().NoMoreThan().Until(Element.IsPresent())
        // Wait(maxWait).Until(element.DoesSomething);
        // .IsPresent()
        // .IsVisible()
        // .IsEnabled()
        // .IsStale()
        // ... etc belong to WebElement and must return immediately.

        // MAX WAIT  =  used accross the framework (eq webdriver    IMPLICIT WAIT)

        // waiting is the sole responsability of Wait method.
        protected static ILog Log = LogManager.GetLogger(typeof(TestBase));

        protected Browser Browser = new WebDriverBrowser(ConfigurationManager.Load());

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
        }

        public virtual void TestSetUp()
        {
        }

        public virtual void TestTearDown()
        {
        }
    }
}
