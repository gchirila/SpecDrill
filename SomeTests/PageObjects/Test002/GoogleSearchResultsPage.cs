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
        [Find(By.CssSelector, "div.content div.mw div.g")]
        public ListElement<SearchResultItemControl> SearchResults { get; private set; }
        public GoogleSearchResultsPage()
            : base(string.Empty)
        {
            //SearchResults = WebElement.CreateList<SearchResultItemControl>(this, ElementLocator.Create(By.CssSelector, "div.content div.mw div.g"));
                //new ListElement<SearchResultItemControl>(this, ElementLocator.Create(By.CssSelector, "div.content div.mw div.g"));
        }
    }
}
