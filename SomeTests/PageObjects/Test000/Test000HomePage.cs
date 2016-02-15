using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SpecDrill;
using SpecDrill.SecondaryPorts.AutomationFramework;

namespace SomeTests.PageObjects.Test000
{
    public class Test000HomePage : WebPage
    {
        public IElement TxtUserName { get; private set; }
        public IElement TxtPassword { get; private set; }
        public INavigationElement<Test000HomePage> BtnLogin { get; private set; }

        public Test000HomePage(Browser browser)
            : base(browser, "Virtual Store - Home")
        {
            this.TxtUserName = WebElement.Create(this.Browser, this, Locator.Create(By.Id, "userName"));
            this.TxtPassword = WebElement.Create(this.Browser, this, Locator.Create(By.Id, "password"));
            this.BtnLogin = WebElement.CreateNavigation<Test000HomePage>(this.Browser, this, Locator.Create(By.Id, "login"));
        }
    }
}
