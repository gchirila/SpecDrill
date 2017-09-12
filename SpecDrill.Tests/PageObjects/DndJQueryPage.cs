using SpecDrill;
using SpecDrill.SecondaryPorts.AutomationFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeTests.PageObjects.Alerts
{
    public class DndJQueryPage : WebPage
    {
        [Find(By.Id, "card5")]
        public IElement DivCard5 { get; private set; }

        [Find(By.CssSelector, "#cardSlots>div:nth-child(5)")]
        public IElement DivDropTargetCard5 { get; private set; }
    }
}
