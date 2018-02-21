using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeTests.PageObjects.Test001;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeTests
{
    [TestClass]
    public class ScreenshotTests : TestBaseTests
    {
        [TestMethod]
        public void ShouldSaveScreenshotSuccessfully()
        {
            var randomPage = Browser.Open<Test001CalculatorPage>();
        }

        public override void TestCleanup()
        {
            base.SaveScreenshot();
        }
    }
}
