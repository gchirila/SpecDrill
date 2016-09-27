using SpecDrill.SecondaryPorts.AutomationFramework;
using System;
using System.Collections.Generic;
using SpecDrill.SecondaryPorts.AutomationFramework.Core;
using System.Collections;
using System.Text.RegularExpressions;

namespace SpecDrill
{
    public class WebControl : ElementBase, IControl
    {
        public WebControl(IBrowser browser, IElement parent, IElementLocator locator) : base(browser, parent, locator)
        {
        }
        public WebControl(IElement parent, IElementLocator locator) : base(parent.Browser, parent, locator) { }
        public bool IsLoaded
        {
            get
            {
                return this.rootElement.IsAvailable;
            }
        }
    }
}
