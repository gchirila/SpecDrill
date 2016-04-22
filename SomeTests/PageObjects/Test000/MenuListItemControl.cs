using SpecDrill;
using SpecDrill.SecondaryPorts.AutomationFramework;
using SpecDrill.SecondaryPorts.AutomationFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeTests.PageObjects.Test000
{
    public class MenuListItemControl : WebControl
    {
        public MenuListItemControl(IBrowser browser, IElement parent, IElementLocator locator) : base(browser, parent, locator)
        {
            LnkLogin = WebElement.CreateNavigation<Test000LoginPage>(browser, parent, ElementLocator.Create(By.PartialLinkText, "Login"));
            LnkHome = WebElement.CreateNavigation<Test000HomePage>(browser, parent, ElementLocator.Create(By.PartialLinkText, "Home"));
        }

        public INavigationElement<Test000LoginPage> LnkLogin { get; private set; }
        public INavigationElement<Test000HomePage> LnkHome { get; private set; }
    }
}
