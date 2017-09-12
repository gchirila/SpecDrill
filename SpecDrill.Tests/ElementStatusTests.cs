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
using SomeTests.PageObjects;

namespace SomeTests
{
    [TestClass]
    public class ElementStatusTests : TestBase
    {
        [TestMethod]
        public void ShouldWaitForElementToBecomeDisabled()
        {
            var elStatusPage = Browser.Open<ElementStatusPage>();

            var disablingElement = WebElement.Create(null, ElementLocator.Create(By.Id, "willBeDisabled"));

            using (var benchmark = new BenchmarkScope("Time Until Disable"))
            {
                Wait.NoMoreThan(TimeSpan.FromSeconds(3)).Until(() => !disablingElement.IsEnabled);
                benchmark.Elapsed.Should().BeCloseTo(TimeSpan.FromSeconds(2), 300);
            }
        }

        [TestMethod]
        public void ShouldWaitForElementToBecomeVisible()
        {
            var elStatusPage = Browser.Open<ElementStatusPage>();

            var disablingElement = WebElement.Create(null, ElementLocator.Create(By.Id, "willBeDisplayed"));

            using (var benchmark = new BenchmarkScope("Time Until Display"))
            {
                Wait.NoMoreThan(TimeSpan.FromSeconds(3)).Until(() => disablingElement.IsDisplayed);
                benchmark.Elapsed.Should().BeCloseTo(TimeSpan.FromSeconds(2), 300);
            }
        }
    }
}
