using SpecDrill;
using SpecDrill.SecondaryPorts.AutomationFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeTests.PageObjects.Alerts
{
    public class DndHtml5Page : WebPage
    {
        [Find(By.Id, "drag1")]
        public IElement DivDraggable { get; private set; }

        [Find(By.Id, "div1")]
        public IElement DivDropTarget { get; private set; }
    }
}
