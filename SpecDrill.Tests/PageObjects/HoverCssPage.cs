using SpecDrill;
using SpecDrill.SecondaryPorts.AutomationFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeTests.PageObjects.Alerts
{
    public class HoverCssPage : WebPage
    {
        [Find(By.CssSelector, ".tooltip")]
        public IElement DivTooltip { get; private set; }

        [Find(By.CssSelector, ".tooltiptext")]
        public IElement DivTooltipText { get; private set; }
    }
}
