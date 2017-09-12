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

namespace SomeTests
{
    [TestClass]
    public class DndTests : TestBase
    {
        [TestMethod]
        public void ShouldHtml5DragAndDropSuccessfuly()
        {
            var hoverPage = Browser.Open<DndHtml5Page>();

            hoverPage.DivDraggable.DragAndDropTo(hoverPage.DivDropTarget);

            var droppedElement = WebElement.Create(null, ElementLocator.Create(By.CssSelector, "#div1>#drag1"));
            
            Wait.NoMoreThan(TimeSpan.FromSeconds(2)).Until(() => droppedElement.IsAvailable);

            droppedElement.IsAvailable.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldJQueryDragAndDropSuccessfuly()
        {
            var hoverPage = Browser.Open<DndJQueryPage>();

           hoverPage.DivCard5.DragAndDropTo(hoverPage.DivDropTargetCard5);

            hoverPage.DivDropTargetCard5.GetAttribute("aria-disabled").Should().Be("true");
        }

        [TestMethod]
        public void ShouldJsPlumbDragAndDropSuccessfuly()
        {
            var hoverPage = Browser.Open<DndJsPlumbPage>();
            Wait.Until(() => hoverPage.DivDraggable.IsAvailable);
            hoverPage.DivDraggable.DragAndDropTo(hoverPage.DivDropTarget);

            hoverPage.DivDropTarget.GetAttribute("class").Should().Contain("jtk-endpoint-connected");
        }
    }
}
