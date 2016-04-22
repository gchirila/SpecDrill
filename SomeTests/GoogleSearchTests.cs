using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeTests.PageObjects.Test002;
using SpecDrill;
using SpecDrill.MsTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeTests
{
    [TestClass]
    public class GoogleSearchTests : TestBase
    {
        [TestMethod]
        public void ShouldHaveResultsWhenSearchingGoogle()
        {
            var googleSearchPage = Browser.Open<GoogleSearchPage>();
            googleSearchPage.TxtSearch.SendKeys("drill");
            System.Threading.Thread.Sleep(3000);
        }
    }
}
