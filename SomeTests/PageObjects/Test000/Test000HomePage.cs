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
        public IElement LblUserName { get; private set; }
        public INavigationElement<Test000HomePage> BtnLogin { get; private set; }
        public MenuListItemControl CtlMenu { get; private set; }

        public Test000HomePage()
            : base("Virtual Store - Home")
        {
            this.LblUserName = WebElement.Create(this, ElementLocator.Create(By.Id, "username"));
            this.BtnLogin = WebElement.CreateNavigation<Test000HomePage>(this, ElementLocator.Create(By.Id, "login"));
            this.CtlMenu = WebElement.CreateControl<MenuListItemControl>(this, ElementLocator.Create(By.Id, "menu"));
        }
    }
}
