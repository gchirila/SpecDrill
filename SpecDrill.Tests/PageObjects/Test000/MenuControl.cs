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
    public class MenuControl : WebControl
    {
        [Find(By.Id, "userName")]
        public IElement TxtUserName { get; private set; }
        [Find(By.Id, "password")]
        public IElement TxtPassword { get; private set; }
        [Find(By.Id, "login")]
        public INavigationElement<Test000HomePage> BtnLogin { get; private set; }

        public MenuControl(IElement parent, IElementLocator locator)
            : base(parent, locator)
        {
            //this.TxtUserName = WebElement.Create(this, ElementLocator.Create(By.Id, "userName"));
            //this.TxtPassword = WebElement.Create(this, ElementLocator.Create(By.Id, "password"));
            //this.BtnLogin = WebElement.CreateNavigation<Test000HomePage>(this, ElementLocator.Create(By.Id, "login"));
        }
    }
}
