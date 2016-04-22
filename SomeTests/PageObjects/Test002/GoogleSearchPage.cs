using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SpecDrill;
using SpecDrill.SecondaryPorts.AutomationFramework;

namespace SomeTests.PageObjects.Test002
{
    public class GoogleSearchPage : WebPage
    {
        public IElement TxtSearch { get; private set; }

        public INavigationElement<GoogleSearchResultsPage> BtnSearch { get; private set; }

        public IElement TxtResult { get; private set; }

        public GoogleSearchPage(Browser browser, string titlePattern = "")
            : base(browser, titlePattern)
        {
            this.TxtSearch = WebElement.Create(this.Browser, this, ElementLocator.Create(By.Id, "input#lst-ib"));
            this.BtnSearch = WebElement.CreateNavigation<GoogleSearchResultsPage>(this.Browser, this, ElementLocator.Create(By.XPath, "//input[name='btnK']"));
        }
    }
}
