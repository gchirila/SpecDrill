using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeTests.PageObjects.Test000;
using SpecDrill;
using SpecDrill.MsTest;
using FluentAssertions;
using SpecDrill.AutomationScopes;
using SomeTests.PageObjects.Alerts;
using SpecDrill.SecondaryPorts.AutomationFramework;
using SomeTests.PageObjects.Test001;

namespace SomeTests
{
    [TestClass]
    public class BrowserTests : TestBase
    {
        [TestMethod]
        public void ShouldConfirmEnableVncCapabilityIsSet()
        {
            var capabilities = Browser.GetCapabilities();
            capabilities.ContainsKey("enableVNC").Should().BeTrue();
            (capabilities["enableVNC"] is bool).Should().BeTrue();
            ((bool)capabilities["enableVNC"]).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReadCorrectUrl()
        {
            var calculatorPage = Browser.Open<Test001CalculatorPage>();
            Uri currentUrl = Browser.Url;

            currentUrl.IsFile.Should().BeTrue();
            currentUrl.PathAndQuery.EndsWith("/WebsiteMocks/Test001/calculator.html");
        }
    }
}
