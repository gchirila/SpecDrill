using SpecDrill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecDrill.SecondaryPorts.AutomationFramework;
using SpecDrill.SecondaryPorts.AutomationFramework.Core;

namespace SomeTests.PageObjects.Test002
{
    public class SearchResultItemControl : WebControl
    {
        public IElement Link { get; }
        public IElement Description { get; }
        public SearchResultItemControl(IBrowser browser, IElement parent, IElementLocator locator) : base(browser, parent, locator)
        {
            Link = WebElement.Create(this.Browser, this, ElementLocator.Create(By.CssSelector, "div a"));
            Description = WebElement.Create(this.Browser, this, ElementLocator.Create(By.CssSelector, "div.rc>div.s>span.st"));
        }
    }
}
