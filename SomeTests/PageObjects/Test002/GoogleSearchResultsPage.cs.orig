using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SpecDrill;
using SpecDrill.SecondaryPorts.AutomationFramework;
using SpecDrill.WebControls;

namespace SomeTests.PageObjects.Test002
{
    public class GoogleSearchResultsPage : GoogleSearchPage
    {
        public ListElement<SearchResultItemControl> SearchResults { get; }
        public GoogleSearchResultsPage(Browser browser)
            : base(browser, "")
        {
            SearchResults = new ListElement<SearchResultItemControl>(this, ElementLocator.Create(By.CssSelector, "div.content div.mw div.g"));
        }
    }
}
