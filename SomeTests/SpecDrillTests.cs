using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeTests.PageObjects.Test000;
using SpecDrill;

namespace SomeTests
{
    [TestClass]
    public class SpecDrillTests : TestBase
    {
        public void ShouldOpenBrowserWhenHomepageIsOpened()
        {
            var virtualStoreHomePage = Browser.Open<Test000Page>();
            Assert.AreEqual("Virtual Store - Login", Browser.PageTitle);
        }
    }
}
