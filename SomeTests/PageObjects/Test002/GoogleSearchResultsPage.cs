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
    public class GoogleSearchResultsPage : GoogleSearchPage
    {

        public GoogleSearchResultsPage(Browser browser)
            : base(browser, "Google Search")
        {
            //this.TxtResult = WebElement.CreateSelect(this.Browser, this, ElementLocator.Create(By.Id, "result"));
        }
    }
}
