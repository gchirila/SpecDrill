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
    public class Test000LoginPage : WebPage
    {
        public IElement TxtUserName { get; private set; }
        public IElement TxtPassword { get; private set; }
        public INavigationElement<Test000HomePage> BtnLogin { get; private set; }

        public ISelectElement DdlCountry { get; private set; }
        public ISelectElement DdlCity { get; private set; }

        public MenuListItemControl CtlMenu { get; private set; }

        public Test000LoginPage(Browser browser)
            : base(browser, "Virtual Store - Login")
        {
            this.TxtUserName = WebElement.Create(this.Browser, this, ElementLocator.Create(By.Id, "userName"));
            this.TxtPassword = WebElement.Create(this.Browser, this, ElementLocator.Create(By.Id, "password"));
            this.BtnLogin = WebElement.CreateNavigation<Test000HomePage>(this.Browser, this, ElementLocator.Create(By.Id, "login"));
            this.DdlCountry = WebElement.CreateSelect(this.Browser, this, ElementLocator.Create(By.Id, "country"));
            this.DdlCity = WebElement.CreateSelect(this.Browser, this, ElementLocator.Create(By.Id, "city"));
            this.CtlMenu = WebElement.CreateControl<MenuListItemControl>(this.Browser, this, ElementLocator.Create(By.Id, "menu"));
        }
    }
}
